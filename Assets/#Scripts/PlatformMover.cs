using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour {

	public static Rigidbody2D g;
	public PlayerController tPC; //   you cannot assign the herirchy objs to prefabs so have to use FindObjectof type

	public float timeStore;
	public float thresholdTime;

	public float MagNitue;

	// Use this for initialization
	void Start () {
		//thresholdTime = 0.2f;

		g = GetComponent<Rigidbody2D> ();
		timeStore = thresholdTime;
	
		tPC = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (tPC.grounded)
		{
			thresholdTime -= Time.deltaTime;
		}

		if(thresholdTime<0)	// then platforfm starts sinking
		{
			g.isKinematic = false; //   activated

			           //rigidbody2D.AddForce(transform.right * speed);
//			g.AddForce(transform.right*MagNitue);

//			g.AddForce(transform.up*(-1*MagNitue));
		}

	
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) 
		{thresholdTime = timeStore;
			g.isKinematic = true;//deactivated
		}
		// for activating rigidbody physics use g.isKinematic=false;
	}
}
