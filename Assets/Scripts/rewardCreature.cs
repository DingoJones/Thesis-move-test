using UnityEngine;
using System.Collections;

public class rewardCreature : MonoBehaviour {
	private float moveInterval;  //Seconds between each move.
	private float moveVelocity;  //How fast wolf chases.
	private float wolfProximity;
	private float runVelocity;

	public GameObject Rwrd;
	public GameObject Wolf;
	public GameObject Home;


	private Transform wolf;
	private Transform home;

	private NavMeshAgent reward;

	private Transform player; 


	private Vector3 startPos;
	private Transform rwrdTr;

	public bool run;			//the comand to bring the wolf to the player
	public bool reload;			//how the wolf moves to the player
	public bool idle;			//how the wolf behaves when not 

	// Use this for initialization
	void Start () {
		moveInterval = 50;
		moveVelocity = 7.5f;
		runVelocity = 20f;
		wolfProximity = 1;

		//Rwrd = GameObject.FindWithTag("Reward").GetComponent<Transform>();
		wolf = GameObject.FindWithTag("Wolf").GetComponent<Transform>();
		reward = GetComponent<NavMeshAgent>();
		rwrdTr = GetComponent<Transform>();
		startPos = rwrdTr.position;
		player = GameObject.FindWithTag("Player").GetComponent<Transform>();
		home = GameObject.FindWithTag("Home").GetComponent<Transform>();


		run = false;			//the comand to bring the wolf to the player
		reload = false;			//how the wolf moves to the player
		idle = true;	
	}
	
	// Update is called once per frame
	void Update () {
		if ((Vector3.Distance (wolf.position, rwrdTr.position) < wolfProximity)) {
			run = true;
			idle = false;
		}

		if (run == true) {
			rwrdTr.LookAt(wolf);
			rwrdTr.Translate(runVelocity * Vector3.back * Time.deltaTime);
			//Destroy(gameObject, 1);
		}

	}
}
