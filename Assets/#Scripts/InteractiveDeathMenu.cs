using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveDeathMenu : MonoBehaviour {

	public Text scrText;
	public ScoreManager sMG;
	public int i=0;
	public int rem;

	public AudioSource chime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		/*    latest 18 dec 18
		rem = (int)sMG.scoreCount - i;

		scrText.text = "You Have Scored "+i+" pts";

		if (rem > 52) {
			if (sMG.scoreCount < 100) {
				i = i + 1;
			} else if (sMG.scoreCount < 500) {
				i = i + 11;
			} else if (sMG.scoreCount < 1000) {
				i = i + 21;
			} else if (sMG.scoreCount < 5000) {
				i = i + 51;
			} else {
				i = i + 101;
			}
		} else {
			i = i + 1;

			//chime.Play ();
		}





		if (i > sMG.scoreCount) {
			i = (int)sMG.scoreCount + 1;
			//chime.Stop ();
		}
		if (i ==sMG.scoreCount) 
		{//chime.Stop ();
		}
			*/

		i = (int)sMG.scoreCount;
		scrText.text = "You Have Scored "+i+" pts";
	}
}
