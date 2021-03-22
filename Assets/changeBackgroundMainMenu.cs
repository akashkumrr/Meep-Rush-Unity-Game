using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeBackgroundMainMenu : MonoBehaviour {

	public Material[] mat;
	public float f;

	// Use this for initialization
	void Start () {
		MeshRenderer rend = GetComponent<MeshRenderer> ();

		f = Random.Range (0, 10);
		if (f < 2) {
			rend.material = mat [0];
		}
		else if (f <= 6) 
		{
			rend.material = mat [1];	
		}
		else 
		{
			rend.material = mat [2];	
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
