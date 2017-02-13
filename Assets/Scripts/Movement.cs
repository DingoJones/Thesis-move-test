using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed = 5;
	public GameObject chara;
	//private Transform movement;

	public float rotateSpeed = 3.0F;
	public Vector3 moveDirection = Vector3.zero;
	public bool isGrounded;
	public bool canPlayerControl;

	//private NavMeshAgent player;

	// Use this for initialization
	void Start () {

		//player = GetComponent<NavMeshAgent>();
		//movement = this.GetOrAddComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {
		//movement.Translate(new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical")) * Time.deltaTime * Speed);

		CharacterController controller = GetComponent<CharacterController>();
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;

		if (canPlayerControl){
			controller.Move(moveDirection * Time.deltaTime);
	}


	}
}
