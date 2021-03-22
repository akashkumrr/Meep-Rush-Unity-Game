using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class unlockingMode : MonoBehaviour {


	public TextMeshProUGUI t;
	public int missionNoUnlock;

	// Use this for initialization
	void Start () {

		if (PlayerPrefs.GetInt ("missionNO") >= missionNoUnlock) {
			this.gameObject.SetActive (false);
		} 
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void unlockScr()
	{
		

		if (PlayerPrefs.GetInt ("missionNO") >= missionNoUnlock) {
			this.gameObject.SetActive (false);
		} 
		else 
		{
			StartCoroutine (unlockText ());
		}
	}

	IEnumerator unlockText()
	{
		t.CrossFadeAlpha (1.0f, 1, false);

		t.text="Complete "+ missionNoUnlock+" missions to unlock this mode";
		yield return new WaitForSeconds (3);

		t.CrossFadeAlpha (0.0f, 2, false);


	}
}
