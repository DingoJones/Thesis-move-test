using UnityEngine;
using System.Collections;

public class Move2 : MonoBehaviour {
		public GameObject Marker;
		public float speed = 8.0F;
		public float jumpSpeed = 8.0F;
		public float jumpHeightIncrease = 1.5F;
		public float gravity = 15.0F;
		public float rotateSpeed = 3.0F;
		public float jumpSpeedAirMove;
		public Vector3 moveDirection = Vector3.zero;
		public bool canPlayerControl;
		public bool isGrounded;
		private bool bDisplayEnd;

		private Vector3 startPosition;

		private Animator anim;


		void Start()
		{
			bDisplayEnd = false;
			canPlayerControl = true;
			anim = GetComponentInChildren<Animator>();
			startPosition = transform.position;
		}

		void Update() 
		{
			CharacterController controller = GetComponent<CharacterController>();

			// Setup move directions
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;

			// Jump!
			if (controller.isGrounded)
			{
				jumpSpeedAirMove = 0;                 // a grounded character has zero vertical speed unless...
				if (Input.GetButtonDown("Jump"))
				{     
					anim.SetTrigger ("jump");
					jumpSpeedAirMove = jumpSpeed;
				}
			}

			// Apply gravity and move the player controller
			jumpSpeedAirMove -= gravity * Time.deltaTime;
			moveDirection.y = jumpSpeedAirMove * jumpHeightIncrease;

			if (canPlayerControl)
				controller.Move(moveDirection * Time.deltaTime);
		}


		void OnTriggerEnter(Collider other)
		{
			if (other.tag == "ActivationBoundary")
			{
				Marker.transform.parent = gameObject.transform;
				Marker.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
				Transform MandalaObject = Marker.transform.GetChild(0);
				MandalaObject.transform.Translate(Vector3.forward * 8, Space.Self);

				Destroy(other.gameObject);
			}

			if (other.tag == "Floor")
			{

				//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				//CameraController.BeginningAnim = false;

			}

		}

	}