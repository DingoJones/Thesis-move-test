using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Monster : MonoBehaviour {
	private float moveInterval;  //Seconds between each move.
	private float moveVelocity;  //How fast wolf chases.
	private float runProximity; 
	private float chaseProximity; 


	public GameObject Player;	//the player character
	public GameObject Wolf;		//the wolf
	public GameObject Anxiety;	//the marker


	private Transform player;

	private NavMeshAgent anxiety;

	private Transform wolf; 


	private Vector3 startPos;
	private Transform anxietyTr;


	public bool run;			//the comand to bring the wolf to the player
	public bool chase;			//how the wolf moves to the player
	public bool idle;			//how the wolf behaves when not 

	// Use this for initialization
	void Start () {

		moveInterval = 2;
		moveVelocity = 5f;
		runProximity = 8;
		chaseProximity = 5;

		player = GameObject.FindWithTag("Player").GetComponent<Transform>();
		anxiety = GetComponent<NavMeshAgent>();
		anxietyTr = GetComponent<Transform>();
		startPos = anxietyTr.position;
		wolf = GameObject.FindWithTag("Wolf").GetComponent<Transform>();

		run = false;
		chase = false;
		idle = true;


	}

	// Update is called once per frame
	void Update () {
		/*
		if (!run && !chase)  {
			StartCoroutine(movementCycle());

		}
*/
		/*
		if (!idle && (Vector3.Distance(wolf.position, anxietyTr.position) > runProximity) && (Vector3.Distance(player.position, anxietyTr.position) > runProximity)) {
			idle = true;
			chase = false;
			run = false;
			print ("stop");

		}
		*/
		if (!chase && !run && (Vector3.Distance (player.position, anxietyTr.position) < chaseProximity)) {
			idle = false;
			chase = true;
			run = false;
			print ("chase");

		}

		if (!run && (Vector3.Distance (wolf.position, anxietyTr.position) < runProximity)) {
			idle = false;
			chase = false;
			run = true;
			print ("run");

		}

		if (run == true) {
			chase = false;
			idle = false;
			print ("runaway");
			anxietyTr.LookAt (wolf);
			anxietyTr.Translate (moveVelocity * Vector3.back * Time.deltaTime);
		}

		if (chase == true) {
			
			anxietyTr.LookAt (player);
			anxietyTr.Translate (moveVelocity * Vector3.forward * Time.deltaTime);
		}

		if ( run == true && !chase && (Vector3.Distance (wolf.position, anxietyTr.position) > runProximity)) {
			idle = true;
			chase = false;
			run = false;

		}
	}



		/*
		if (wolf reaches last call location stop) {
			call = false;
			move = false;
			idle = true; 

		}

	
		IEnumerator movementCycle ()   {
		
			idle = true;
			print ("idle");

			NavMeshHit hit;

			Vector3 randomPos = (Random.insideUnitSphere * 10) + startPos;
			NavMesh.SamplePosition(randomPos, out hit, 7, 1);
			anxiety.destination = hit.position;

			yield return new WaitForSeconds(moveInterval); 
			idle = false;

	}
	*/
	void OnTriggerEnter(Collider obj)     {
		if (obj.gameObject.tag == "Player")   {
			//Reset level
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			print ("killed");
		}
	}

}

