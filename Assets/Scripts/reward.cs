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
	

	}

	void OnTriggerEnter(Collider obj)     {
		if (obj.gameObject.tag == "Rewarda")   {
			playerCounter = (playerCounter + 1);
			print (playerCounter);
			//obj.gameObject.SetActive (false);
			Destroy (obj.gameObject);

		}
		if (obj.gameObject.tag == "Rewardb")   {
			playerCounter = (playerCounter + 1);
			print (playerCounter);
			//obj.gameObject.SetActive (false);
			Destroy (obj.gameObject);

		}
		if (obj.gameObject.tag == "Rewardc")   {
			playerCounter = (playerCounter + 1);
			print (playerCounter);
			//obj.gameObject.SetActive (false);
			Destroy (obj.gameObject);

		}
		if (obj.gameObject.tag == "Rewardd")   {
			playerCounter = (playerCounter + 1);
			print (playerCounter);
			//obj.gameObject.SetActive (false);
			Destroy (obj.gameObject);

		}
		if (obj.gameObject.tag == "Rewarde")   {
			playerCounter = (playerCounter + 1);
			print (playerCounter);
			//obj.gameObject.SetActive (false);
			Destroy (obj.gameObject);

		}
		if (obj.gameObject.tag == "Rewardf")   {
			playerCounter = (playerCounter + 1);
			print (playerCounter);
			//obj.gameObject.SetActive (false);
			Destroy (obj.gameObject);

		}
		if (obj.gameObject.tag == "Rewardg")   {
			playerCounter = (playerCounter + 1);
			print (playerCounter);
			//obj.gameObject.SetActive (false);
			Destroy (obj.gameObject);

		}		
		if (obj.gameObject.tag == "Rewardh")   {
			playerCounter = (playerCounter + 1);
			print (playerCounter);
			//obj.gameObject.SetActive (false);
			Destroy (obj.gameObject);

		}
	}
}
