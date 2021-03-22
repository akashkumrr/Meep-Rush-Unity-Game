using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateBG : MonoBehaviour {

	public float speed;
	public float posWhere;

	public Vector3 startPos;

	// Use this for initialization
	void Start () {
		//startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate ((new Vector3 (-1, 0, 0)) * speed * Time.deltaTime);

		if (transform.position.x < posWhere) 
		{
			transform.position = startPos;
		}
	}
}
