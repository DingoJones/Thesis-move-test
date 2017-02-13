using UnityEngine;
using System.Collections;
/*if rest state is  true walk randomly
 *if rest state is false move to GameObject player
 *rest state is false when player hits mouse2
 *rest state is true if wolf hits player
 */

public class Follow : MonoBehaviour {
	private float moveInterval;  //Seconds between each move.
	private float moveVelocity;  //How fast wolf chases.
	private float chaseProximity; 

	public GameObject Player;	//the player character
	public GameObject Wolf;		//the wolf
	//public GameObject Beacon;	//the marker


	private Transform player;

	private NavMeshAgent wolf;

	//private Transform beacon; 

	private Vector3 startPos;
	private Transform wolfTr;


	public bool call;			//the comand to bring the wolf to the player
	public bool move;			//how the wolf moves to the player
	public bool idle;			//how the wolf behaves when not 

	// Use this for initialization
	void Start () {

		moveInterval = 50;
		moveVelocity = 7.5f;
		chaseProximity = 2;

		player = GameObject.FindWithTag("Player").GetComponent<Transform>();
		wolf = GetComponent<NavMeshAgent>();
		wolfTr = GetComponent<Transform>();
		startPos = wolfTr.position;
		//beacon = GameObject.FindWithTag("Beacon").GetComponent<Transform>();

		call = false;
		move = false;
		idle = true;


	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (!move && !call)  {
			StartCoroutine(movementCycle());
		}
		*/
		if (!idle && (Vector3.Distance(player.position, wolfTr.position) < chaseProximity)) {
			idle = true;
			move = false;
			call = false;
			print ("stop");

		}

		if (Input.GetMouseButtonDown(0)){
			print("mouse1 was pressed");
			call = true;
			 
		}

		if (call == true) {
			move = true;
			idle = false;
			print ("called");
		}

		if (move == true) {
			wolfTr.LookAt(player);
			wolfTr.Translate(moveVelocity * Vector3.forward * Time.deltaTime);
		}
			

		/*
		if (wolf reaches last call location stop) {
			call = false;
			move = false;
			idle = true; 

		}
*/

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

}
