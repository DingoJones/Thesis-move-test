using UnityEngine;
using System.Collections;

public class rewardWolf : MonoBehaviour {
	public GameObject wolf;	//the player character

	public bool wolfGet;

	public int wolfCounter;
	// Use this for initialization
	void Start () {
	
		wolfCounter = 0;

		wolf = GameObject.FindWithTag("Wolf");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider obj)     {

		print (obj); 
		if (obj.gameObject.tag == "Reward")   {
			wolfCounter = (wolfCounter + 1);
			print (wolfCounter);
			obj.gameObject.SetActive (false);

		}
	}

}
	

