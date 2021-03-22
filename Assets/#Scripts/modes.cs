using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class modes : MonoBehaviour {

	public GameObject modeScreen;
	[Space(10)]
	public int missionNoLvlUnlock;
	public GameObject lockedScr;
	[Space(10)]
	public int missionNoLvlUnlock2;
	public GameObject lockedScr2;
	[Space(10)]
	public int missionNoLvlUnlock3;
	public GameObject lockedScr3;
	[Space(10)]


	public TextMeshProUGUI thisIsLocked;

	public int misNo;
	public TextMeshProUGUI missionNoText;

	// Use this for initialization
	void Start () {
		misNo = PlayerPrefs.GetInt ("missionNO");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void ActivateModeScreen()
	{
		misNo = PlayerPrefs.GetInt ("missionNO");
		modeScreen.SetActive (true);
		if (misNo <= 20) {
			missionNoText.text = "Mission  " + misNo.ToString ();
		} 
		else 
		{
			missionNoText.text = "COMPLETED";
		}
	}

	public void DeactivateModeScreen()
	{
		modeScreen.SetActive (false);
	}


	public void PlayRopeMode()
	{

		SceneManager.LoadScene("endless roped");
	}

	public void PlayGravityMode()
	{
		
		SceneManager.LoadScene("endless gravity falls");
	}




	public void PlayNightMode()
	{
		//  this is on play button of each mode.
		// diff modes will req diff scenes and diff function like this

		//Application.oadlevel.
		SceneManager.LoadScene("endless night");
	}

	public void PlayFullBetaMode()
	{
		SceneManager.LoadScene ("FullgenerationCions Mission 1");
	}

	public void PlayFullBeta2Mode()
	{
		SceneManager.LoadScene ("FullgenerationCions Mission 1b (moving BG chgd) ORTHO");
	}

	public void PlayMissionMode()
	{
		SceneManager.LoadScene("FullgenerationCions Mission 1b (moving BG changed)");
	}

	public void PlayFullGenCoins8ORTHO1()
	{
		SceneManager.LoadScene("FullgenerationCions Mission 8 ORTHO 1");
	}

	public void lockScr()
	{
		
		if (misNo > missionNoLvlUnlock) {
			lockedScr.SetActive (false);
		}


		if (misNo> missionNoLvlUnlock2)
		{
			lockedScr2.SetActive (false);
		}

		if (misNo> missionNoLvlUnlock3) 
		{
			lockedScr3.SetActive (false);
		}


		
	}


}
