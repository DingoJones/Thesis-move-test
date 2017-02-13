using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace ScrapyardChar
{
	public class TPC : MonoBehaviour
	{

		public float speed;
		private float h, v;
		private Rigidbody rb;
		private bool isMoving;
		public float rotationSpeed = 8;

		//private bool gameStart = true;


		void Start ()
		{
			
			rb = GetComponent<Rigidbody> ();
			//Invoke ("canControlCharacter", 1f);
		}

	//	void canControlCharacter () {

			//gameStart = true;
		//}
		void Update ()
		{
			//if (gameStart) {
				h = Input.GetAxis ("Horizontal");
				v = Input.GetAxis ("Vertical");
				isMoving = h != 0 || v != 0;
			//}
		}

		void FixedUpdate ()
		{
			//if (gameStart) {
			//	rb.velocity = rb.angularVelocity = Vector3.zero; Enable it if character tips over or doesn't slow down
				Vector3 newDirection = new Vector3 (h, 0, v);

				if (isMoving) {
					Quaternion targetRotation = Quaternion.LookRotation (newDirection);
					Quaternion newRotation = Quaternion.Slerp (rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
					GetComponent<Rigidbody> ().MoveRotation (newRotation); // Rotate
					rb.MovePosition (transform.position + transform.forward * speed * Time.deltaTime);
				}
			//}
		}
 
    

	}
}

