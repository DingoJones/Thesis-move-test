using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*if rest state is  true walk randomly
 *if rest state is false move to GameObject player
 *rest state is false when player hits mouse2
 *rest state is true if wolf hits player
 */

public class OFollow : MonoBehaviour {
	private float moveInterval;  //Seconds between each move.
	private float moveVelocity;  //How fast wolf chases.
	private float chaseProximity; 
	private float atkProximity; 
	private float rewardProximity;
	private float rewardCollect;

	public GameObject Player;    //the player character
	public GameObject Wolf;        //the wolf
	public GameObject Beacon;    //the marker
	public GameObject Reward;    //the marker


	private Transform player;

	private NavMeshAgent wolf;

	private Transform beacon; 

	private Transform rwrd;


	private Vector3 startPos;
	private Transform wolfTr;

	public int wolfCounter;

	public bool call;            //the comand to bring the wolf to the player
	public bool move;            //how the wolf moves to the player
	public bool idle;            //how the wolf behaves when not 
	public bool atk;
	public bool wrd;
	public bool kll;

	// Use this for initialization
	void Start () {

		moveInterval = 50;
		moveVelocity = 7.5f;
		chaseProximity = 2;
		atkProximity = 3;
		rewardProximity = 7;
		rewardCollect = 2;


		wolfCounter = 0;

		beacon = GameObject.FindWithTag("Marker").GetComponent<Transform>();
		wolf = GetComponent<NavMeshAgent>();
		wolfTr = GetComponent<Transform>();
		startPos = wolfTr.position;
		player = GameObject.FindWithTag("Player").GetComponent<Transform>();
		rwrd = GameObject.FindWithTag("Rewarda").GetComponent<Transform>();


		call = false;
		move = false;
		idle = true;
		atk = false;
		wrd = false;
		kll = false;

	}

	// Update is called once per frame
	void Update () {
		/*
        if (!move && !call)  {
            StartCoroutine(movementCycle());
        }
        */

		if (!idle && (Vector3.Distance (beacon.position, wolfTr.position) < chaseProximity)) {
			idle = true;
			move = false;
			call = false;
			wrd = false;

			print ("stop");
		}

		if ((Vector3.Distance (player.position, wolfTr.position) < atkProximity)) {
			atk = true;
			idle = false;
			move = false;
			call = false;
			wrd = false;


		}

		if (Input.GetMouseButtonDown (0)) {
			print ("mouse1 was pressed");
			call = true;

		}

		if (call == true) {
			move = true;
			idle = false;
			print ("called");
		}

		if (move == true) {
			wolfTr.LookAt (beacon);
			wolfTr.Translate (moveVelocity * Vector3.forward * Time.deltaTime);
		}

		if (atk == true) {
			wolfTr.LookAt (player);
			wolfTr.Translate (moveVelocity * Vector3.forward * Time.deltaTime);
		}


		if ((Vector3.Distance (rwrd.position, wolfTr.position) < rewardProximity)) {
			wrd = true;

		}

		if ((Vector3.Distance (rwrd.position, wolfTr.position) > rewardProximity)) {
			wrd = false;

		}
		if (wrd == true) {
			wolfTr.LookAt (rwrd);
			wolfTr.Translate (moveVelocity * Vector3.forward * Time.deltaTime);
		}

		if ((Vector3.Distance (rwrd.position, wolfTr.position) < rewardCollect)) {
			wolfCounter = (wolfCounter + 1);
			print (wolfCounter);
			//rwrd.gameObject.SetActive (false);
			kll = true;
		}

		if ((Vector3.Distance (rwrd.position, wolfTr.position) < rewardCollect)) {
			kll = false;
		}

		if (wolfCounter > 100) {
			wolfTr.LookAt (player);
			wolfTr.Translate (moveVelocity * Vector3.forward * Time.deltaTime);
		}

	}
	/*
    IEnumerator movementCycle()   {
        idle = true;

        NavMeshHit hit;

        Vector3 randomPos = (Random.insideUnitSphere * 30) + startPos;
        NavMesh.SamplePosition(randomPos, out hit, 10, 1);
        wolf.destination = hit.position;

        yield return new WaitForSeconds(moveInterval); 
        idle = false;
    }
    
*/
	void OnTriggerEnter(Collider obj)     {
		print (obj); 
		if (obj.gameObject.tag == "Player") {
			//Reset level
			if (wolfCounter < 100) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
				print ("killed");
				wolfCounter = 0;
			}

			if (wolfCounter > 100) {
				Destroy (obj.gameObject);
			}

		}
		if (obj.gameObject.tag == "Reward") {
			wolfCounter = (wolfCounter + 1);
			print (wolfCounter);
			obj.gameObject.SetActive (false);

		}

	}

}