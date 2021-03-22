using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackgroundImages : MonoBehaviour {

	public PlayerController cc;
	public GameManager gameKaMan;

	public Vector3 BGstartPoint;

	// Use this for initialization
	void Start () {
		//gameObject.transform.position.x = cc.transform.position.x;
		BGstartPoint=this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//gameObject.transform.position.x = cc.transform.position.x;

		transform.position = new Vector3 (cc.transform.position.x, transform.position.y, transform.position.z);

		if (gameKaMan.revievd)
		{transform.position =BGstartPoint;
			
		}
	}
}
