using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffUpgradeScreen : MonoBehaviour {

	public GameObject upgradeScreen;
	public int misNo;
	public int setNewMisNo;

	public int missionNoLvlUnlock;
	public GameObject lockedPwr;
	[Space(10)]
	public int missionNoLvlUnlock2;
	public GameObject lockedPwr2;
	[Space(10)]
	public int missionNoLvlUnlock3;
	public GameObject lockedPwr3;
	[Space(10)]
	public int setMoneyAmount;




	public void ActivateUpgradeScreen()
	{
		upgradeScreen.SetActive (true);

		if (PlayerPrefs.HasKey ("missionNO")) {
			misNo = PlayerPrefs.GetInt ("missionNO");
		} else {
			misNo = 1;
			PlayerPrefs.SetInt ("missionNO", misNo);
		}

		if (misNo <= missionNoLvlUnlock) {
			lockedPwr.SetActive (true);                         // activates loked window in powerup
		}
		else 
		{
			lockedPwr.SetActive (false);
		}

		if (misNo<= missionNoLvlUnlock2)
		{
			lockedPwr2.SetActive (true);
		}else 
		{
			lockedPwr2.SetActive (false);
		}

		if (misNo<= missionNoLvlUnlock3) 
		{
			lockedPwr3.SetActive (true);
		}else 
		{
			lockedPwr3.SetActive (false);
		}

	}

	public void DeactivateUpgradeScreen()
	{
		upgradeScreen.SetActive (false);
	}

	public void SetMission()
	{
		PlayerPrefs.SetInt ("missionNO", setNewMisNo);
	}

	public void SETMONEY()
	{
		PlayerPrefs.SetInt ("cc", setMoneyAmount);
	}

	void Update () {
		
	}

}
