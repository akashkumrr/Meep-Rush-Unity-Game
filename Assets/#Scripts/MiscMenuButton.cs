using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiscMenuButton : MonoBehaviour {

	public GameObject thePlayerStatsScreen;
	//public PlayerController toGetThings;
	public Text huhText;
	public Text huhText2;
	public Text huhText3;
	public Text huhText4;
	public Text huhText5;






	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		huhText.text = " : " + PlayerPrefs.GetInt ("cc");
		huhText2.text = " : " + Mathf.Round(PlayerPrefs.GetFloat ("rd"))+" meters";
		huhText3.text = " : " + Mathf.Round(PlayerPrefs.GetFloat ("HighScore"));
		huhText4.text = " : " + Mathf.Round(PlayerPrefs.GetFloat ("playTime"));
		huhText5.text = " : " + Mathf.Round(PlayerPrefs.GetFloat ("highSpeed"));

	}


	public void PlayerStats(){
		thePlayerStatsScreen.SetActive (true);
	}

	public void BackToMain(){
		thePlayerStatsScreen.SetActive (false);
	}
}
