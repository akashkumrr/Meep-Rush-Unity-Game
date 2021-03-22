using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGscroller : MonoBehaviour {

	public float speed;

	[Tooltip("the x position after which it should disappear")]
	public float distDisappear;
	Vector3 startPos;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate((new Vector3(-1,0,0))*speed*Time.deltaTime);

		if (transform.position.x < distDisappear)
		{
			transform.position = startPos;

		}
	}
}
