using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingVaribles : MonoBehaviour {

	public bool setMission;
	public int enterMissionNoToBeSettedAt;

	public bool clrAllPrefs;

	public bool setMoney;
	public int enterMoneyAmountToBeSettedAt;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setStuff()
	{
		if (setMission == true) 
		{
			PlayerPrefs.SetInt ("missionNO", enterMissionNoToBeSettedAt);
		}

		if (clrAllPrefs == true) 
		{
			PlayerPrefs.DeleteAll ();
		}

		if (setMoney == true) 
		{
			PlayerPrefs.SetInt ("cc", enterMoneyAmountToBeSettedAt);
		}
	}
}
