using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatColID : MonoBehaviour {
	
	private PlatformDestroyer[] platformList;
	public string PlatName;
	public float DownTime;


	public PlayerController thePC;
	public int track=1;  // this is to find whether the platform collided has changed or not

	// as long as the player is grounded (i.e. it has not jumped while being on that platform) and collided platform name is same then appy force 
	void Start () {
		thePC = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((thePC.grounded)&&(track==-1))
		{
			DownTime -= Time.deltaTime;
		}

		if(DownTime<0)	
		{
			//g.isKinematic = false; 
			//make that named platformList sink

		}


		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) 
		{//DownTime = timeStore;
			//g.isKinematic = true;//deactivated
		}

	}

	void StartForce()
	{
		platformList = FindObjectsOfType<PlatformDestroyer> ();
		for (int i = 0; i < platformList.Length; i++)
		{
			// apply force to a particular object
		}
		
	}

	void OnCollisionEnter2D (Collision2D other)   //      check whether small d or capital D
	{
		if (other.gameObject.tag == "plat")
		{ track = track * -1;
			PlatName = other.gameObject.transform.name;
		}
    }

}
