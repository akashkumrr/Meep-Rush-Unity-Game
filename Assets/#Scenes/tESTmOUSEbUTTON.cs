using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tESTmOUSEbUTTON : MonoBehaviour {
	
	public Rigidbody2D myRigidbody;
	public float jf;
	void OnMouseDown()
	{
		myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jf);

	}
}
