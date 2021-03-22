using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetic : MonoBehaviour {

	public Transform playerPos;
	public float speed;
	public bool magnetZone;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (magnetZone) {
			transform.position = Vector3.MoveTowards (transform.position, playerPos.position, speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "playerAura") 
		{
			magnetZone = true;
		}
	}
}
