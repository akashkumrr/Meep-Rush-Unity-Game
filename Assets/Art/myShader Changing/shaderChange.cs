using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaderChange : MonoBehaviour {

	public Shader s1;
	public Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		s1=Shader.Find("Sprites/Diffuse");
		rend.material.shader = s1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
