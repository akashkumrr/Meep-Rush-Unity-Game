using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jetFireTrail : MonoBehaviour {



	public AnimationClip barAnim;
	public Animation aniComponent;

	public TopPowerUpManager tMan;
	public SpriteRenderer fireTrail;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (tMan.t2 > 0) {
			fireTrail.sortingOrder = 0 ;
			aniComponent.clip = barAnim;
			aniComponent.Play (); 
		} 
		else
		{
			fireTrail.sortingOrder = -1;
		}
	}
}
