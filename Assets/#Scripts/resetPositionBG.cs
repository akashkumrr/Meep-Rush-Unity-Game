using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPositionBG : MonoBehaviour {

	public Vector3 bgStart;
	public GameManager gameKaMan;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameKaMan.revievd)
		{transform.position = bgStart;
			
		}
	}
}
