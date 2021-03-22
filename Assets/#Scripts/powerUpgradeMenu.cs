using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerUpgradeMenu : MonoBehaviour {



	[Tooltip("This should be differnt for different powerUp upgrades as it is used as player prefs so every powerup will be having different level of upgradation")]
	public string upgradeLvlName;

	// why the above variable is declared ; 
	// we need to know at what level it is now and it will be different for different powerup so it has a weird name


	[Tooltip("this is the newTime after upgradatation")]
	public float newTime;

	[Tooltip("To hold playerprefs in time for each powerup")]
	public string upgradedTimeRefrence;

	// why the above variable is declared ; since PlayerPrefs need a string variable to store int, float vars 

	[Tooltip("this is the default time")]
	public float defaultTime;

	public int whichPowerup;

	public int currentLvl;

	public int coinReq;

	private int coinHas;

	public Button buyButton;

	// Use this for initialization
	void Start () {
		//DontDestroyOnLoad (transform.gameObject);
		
		if (PlayerPrefs.HasKey (upgradeLvlName)) {
			currentLvl = PlayerPrefs.GetInt (upgradeLvlName);
		}
		else 
		{
			PlayerPrefs.SetInt (upgradeLvlName, 0);
			currentLvl = 0;
			newTime = defaultTime;

		}

		PlayerPrefs.SetFloat (upgradedTimeRefrence, newTime);

		coinHas = PlayerPrefs.GetInt ("cc");

		Refresh ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (coinHas > coinReq) 
		{
			buyButton.interactable = true;
		}
		
	}


	//  to get real newTime in other scripts first you have to call this refresh function int
	//  that script
	public void Refresh()
	{
		if (currentLvl == 0) 
		{
			coinReq = 200;
			newTime = 5.0f;

		}
		else if(currentLvl == 1) 
		{
			coinReq = 300;
			newTime = 5.5f;

		}else if(currentLvl == 2) 
		{
			coinReq = 500;
			newTime = 6.0f;

		}
		else if(currentLvl == 3) 
		{
			coinReq = 800;
			newTime = 7.0f;

		}
	}



	public void upgradeButtonPressed()
	{
		Refresh ();



		PlayerPrefs.SetInt ("cc", coinHas - coinReq);


			currentLvl++;
			

		if (currentLvl >= 3) 
		{
			currentLvl = 3;
		}
		PlayerPrefs.SetInt (upgradeLvlName, currentLvl);

		PlayerPrefs.SetFloat(upgradedTimeRefrence, newTime);
		
	}



}
