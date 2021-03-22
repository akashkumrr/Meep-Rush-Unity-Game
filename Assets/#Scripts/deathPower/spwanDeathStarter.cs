using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwanDeathStarter : MonoBehaviour {


	public bool deathStarterPowerup;

	public bool spwanDSagain;
	// Use this for initialization
	void Start () {
		deathStarterPowerup = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player" && other.gameObject.tag == "Player") 
		{
			deathStarterPowerup = true;
			spwanDSagain = false; 
		}

	}
}
