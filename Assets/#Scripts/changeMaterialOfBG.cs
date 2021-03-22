using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMaterialOfBG : MonoBehaviour {

	public Shader s1;
	public Shader s2;
	public Renderer rend;

	public bool isNightLevel;


	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		s1 = Shader.Find ("Unlit/Transparent");
		s2 = Shader.Find ("Sprites/Diffuse");

		if (isNightLevel == true) {
			rend.material.shader = s2;
			rend.material.color = new Color ((float)100/255,(float)100/255, (float)100/255, 1);
		} 
		else 
		{
			rend.material.shader = s1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
