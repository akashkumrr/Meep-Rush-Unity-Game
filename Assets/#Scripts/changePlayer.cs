using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePlayer : MonoBehaviour {


	//   ///public RuntimeAnimatorController anim2;

	public RuntimeAnimatorController[] anim;

	[Space(10)]
	public CircleCollider2D magZoneCollider;
	public ScoreManager sMan;
	public PlatformGenerator pGen;


	// Use this for initialization
	void Start () {
	//  ///	this.GetComponent<Animator>().runtimeAnimatorController = anim2 as RuntimeAnimatorController;
		for (int i = 0; i <= 4; ++i) 
		{
			if (PlayerPrefs.GetInt ("uid") == i + 1) {
				this.GetComponent<Animator> ().runtimeAnimatorController = anim [i] as RuntimeAnimatorController;

			}

			}


		if (PlayerPrefs.GetInt ("uid") == 1) {
			// normal meep no spaciality
		} else if (PlayerPrefs.GetInt ("uid") == 2) { 
			// increase pts per sec
			sMan.pointsPerSecond+=5;
		} else if (PlayerPrefs.GetInt ("uid") == 3) {
			pGen.randomCoinThreshold += 15;
			// increse coin generation
		} else if (PlayerPrefs.GetInt ("uid") == 4) {
			

			magZoneCollider.radius = 4.0f;
		} else {

			// increase powerp generation

			pGen.PowerUpThreshold += 10;
			
		}

	}
	
	// Update is called once per frame
	void Update () {




		//Animator amin = gameObject.GetComponent<Animator> ();

		//amin.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load ("player2");// as RuntimeAnimatorController;

		//Declare then Old Inspector Drag and Drop method manually my default AnimatorController (PlayerAC) on anim1 (PlayerACbow) on anim2

	

	}
}
