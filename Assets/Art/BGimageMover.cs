using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGimageMover : MonoBehaviour {

	public float speed;
	public float tm;

	private Renderer myRenderer;
	// Use this for initialization
	void Start () {
		myRenderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		tm += Time.deltaTime;

		//Vector2 offset = new Vector2 (Time.deltaTime * speed, 0);

		Vector2 offset = new Vector2 (tm* speed, 0);

		myRenderer.material.mainTextureOffset = offset;

		//myRenderer.material.mainTextureOffset.x = new float (hey);
		
	}
}
