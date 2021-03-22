using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addedPerkAnim : MonoBehaviour {


	public AnimationClip barAnim;
	public Animation aniComponent;

	// Use this for initialization
	void Start () {
		aniComponent = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		aniComponent.clip = barAnim;
		aniComponent.Play (); 
	}
}
