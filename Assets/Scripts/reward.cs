using UnityEngine;
using System.Collections;

public class reward : MonoBehaviour {
	public GameObject player;	//the player character

	public bool playerGet;

	public int playerCounter;
	// Use this for initialization
	void Start () {
	
		playerCounter = 0;

		player = GameObject.FindWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {
	
		if (playerCounter == 8) {
			print ("winner");
		}

	}

	void OnTriggerEnter(Collider obj)     {
		if (obj.gameObject.tag == "Rewarda")   {
			playerCounter = (playerCounter + 1);
			print (playerCounter);
			//obj.gameObject.SetActive (false);
			Destroy (obj.gameObject);

		}

	}
}
