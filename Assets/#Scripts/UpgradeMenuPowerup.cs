using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeMenuPowerup : MonoBehaviour {

	[Tooltip("this is required to deactivate button when lvl maxed out")]
	public Button upgradeButton;

	[Tooltip("1 for JETPACK ; 2 for MAGNET ; 3 for FULLCOIN")]
	public int pcode;

	public int coinReq;
	public int coinHas;
	public float newTime;
	public int lvl;

	public TextMeshProUGUI coinReqText;
	public TextMeshProUGUI whatLevel;

	[Tooltip("Deleting playerPrefs for powerup upgrades")]
	public bool deleteKeyUpgradePowerup;

	[Space(10)]
	public GameObject lockedPwrScr;

	[Space(10)]
	[Tooltip("Every powerup will have have its own filled levels as it has it own buy button")]
	public GameObject[] filledLvls;

	// Use this for initialization
	void Start () 
	{



		if (lockedPwrScr.activeInHierarchy == true)    //  this tells that if locked then lvl initially should be 0
		{
			if (pcode == 1) 
			{
				PlayerPrefs.SetInt ("JetPackLvl", 0);
				PlayerPrefs.SetFloat ("JetPackTime", 7.0f);
			}

			if (pcode == 2) 
			{
				PlayerPrefs.SetInt ("MagnetLvl", 0);
				PlayerPrefs.SetFloat("MagnetTime", 4.0f);
			}

			if (pcode == 3) 
			{
				PlayerPrefs.SetInt ("FullCoinLvl", 0);
				PlayerPrefs.SetFloat("FullCoinTime", 4.0f);
			}
		}


		if (!PlayerPrefs.HasKey ("JetPackLvl")) 
		{
			PlayerPrefs.SetInt ("JetPackLvl", 0);
		}

		if (!PlayerPrefs.HasKey ("JetPackTime")) 
		{
			PlayerPrefs.SetFloat ("JetPackTime", 7.0f);
		}

		if (!PlayerPrefs.HasKey ("MagnetLvl")) 
		{
			PlayerPrefs.SetInt ("MagnetLvl", 0);
		}

		if (!PlayerPrefs.HasKey ("MagnetTime")) 
		{
			PlayerPrefs.SetFloat("MagnetTime", 4.0f);
		}

		if (!PlayerPrefs.HasKey ("FullCoinLvl")) 
		{
			PlayerPrefs.SetInt ("FullCoinLvl", 0);
		}

		if (!PlayerPrefs.HasKey ("FullCoinTime")) 
		{
			PlayerPrefs.SetFloat("FullCoinTime", 4.0f);
		}


		if (deleteKeyUpgradePowerup == true) {
			if (pcode == 1) {
				PlayerPrefs.DeleteKey ("JetPackLvl");
				PlayerPrefs.DeleteKey ("JetPackTime");
			}

			if (pcode == 2) {
				PlayerPrefs.DeleteKey ("MagnetLvl");
				PlayerPrefs.DeleteKey ("MagnetTime");
			}

			if (pcode == 3) {
				PlayerPrefs.DeleteKey ("FullCoinLvl");
				PlayerPrefs.DeleteKey ("FullCoinTime");
			}
		
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (pcode == 1)
		{
			coinReqText.text = "" + coinReq;
			whatLevel.text ="" + lvl;

			lvl = PlayerPrefs.GetInt ("JetPackLvl");

			if (lvl == 0) 
			{coinReq = 200;
				
				filledLvls [0].SetActive (false);
				filledLvls [1].SetActive (false);
				filledLvls [2].SetActive (false);
				filledLvls [3].SetActive (false);
				filledLvls [4].SetActive (false);

			}
			else if (lvl == 1) 
			{
				coinReq = 500;

				filledLvls [0].SetActive (true);
				filledLvls [1].SetActive (false);
				filledLvls [2].SetActive (false);
				filledLvls [3].SetActive (false);
				filledLvls [4].SetActive (false);

			}
			else if (lvl == 2) 
			{
				coinReq = 700;
				filledLvls [0].SetActive (true);
				filledLvls [1].SetActive (true);
				filledLvls [2].SetActive (true);
				filledLvls [3].SetActive (false);
				filledLvls [4].SetActive (false);

				 
			}
			else 
			{
				upgradeButton.interactable=false;
			
				filledLvls [0].SetActive (true);
				filledLvls [1].SetActive (true);
				filledLvls [2].SetActive (true);
				filledLvls [3].SetActive (true);
				filledLvls [4].SetActive (true);

				coinReqText.text = "MAX";
			
			}


		}


		if (pcode == 2)
		{
			coinReqText.text = "" + coinReq;
			whatLevel.text ="" + lvl;

			lvl = PlayerPrefs.GetInt ("MagnetLvl");

			if (lvl == 0) 
			{coinReq = 200;

				filledLvls [0].SetActive (false);
				filledLvls [1].SetActive (false);
				filledLvls [2].SetActive (false);
				filledLvls [3].SetActive (false);
				filledLvls [4].SetActive (false);

			}
			else if (lvl == 1) 
			{
				coinReq = 500;

				filledLvls [0].SetActive (true);
				filledLvls [1].SetActive (false);
				filledLvls [2].SetActive (false);
				filledLvls [3].SetActive (false);
				filledLvls [4].SetActive (false);

			}
			else if (lvl == 2) 
			{
				coinReq = 700;
				filledLvls [0].SetActive (true);
				filledLvls [1].SetActive (true);
				filledLvls [2].SetActive (true);
				filledLvls [3].SetActive (false);
				filledLvls [4].SetActive (false);


			}
			else 
			{
				upgradeButton.interactable=false;

				filledLvls [0].SetActive (true);
				filledLvls [1].SetActive (true);
				filledLvls [2].SetActive (true);
				filledLvls [3].SetActive (true);
				filledLvls [4].SetActive (true);

				coinReqText.text = "MAX";

			}

		}

		if (pcode == 3)
		{
			coinReqText.text = "" + coinReq;
			whatLevel.text ="" + lvl;

			lvl = PlayerPrefs.GetInt ("FullCoinLvl");

			if (lvl == 0) 
			{coinReq = 200;

				filledLvls [0].SetActive (false);
				filledLvls [1].SetActive (false);
				filledLvls [2].SetActive (false);
				filledLvls [3].SetActive (false);
				filledLvls [4].SetActive (false);

			}
			else if (lvl == 1) 
			{
				coinReq = 500;

				filledLvls [0].SetActive (true);
				filledLvls [1].SetActive (false);
				filledLvls [2].SetActive (false);
				filledLvls [3].SetActive (false);
				filledLvls [4].SetActive (false);

			}
			else if (lvl == 2) 
			{
				coinReq = 700;
				filledLvls [0].SetActive (true);
				filledLvls [1].SetActive (true);
				filledLvls [2].SetActive (true);
				filledLvls [3].SetActive (false);
				filledLvls [4].SetActive (false);


			}
			else 
			{
				upgradeButton.interactable=false;

				filledLvls [0].SetActive (true);
				filledLvls [1].SetActive (true);
				filledLvls [2].SetActive (true);
				filledLvls [3].SetActive (true);
				filledLvls [4].SetActive (true);

				coinReqText.text = "MAX";

			}
	}
	}

	public void ClearPowerupPrefs()
	{

		PlayerPrefs.DeleteKey ("JetPackLvl");
		PlayerPrefs.DeleteKey ("JetPackTime");

		PlayerPrefs.DeleteKey ("MagnetLvl");
		PlayerPrefs.DeleteKey ("MagnetTime");

		PlayerPrefs.DeleteKey ("FullCoinLvl");
		PlayerPrefs.DeleteKey ("FullCoinTime");


		upgradeButton.interactable=true;
	}



	public int buyReference(int coinReq)
	{
		int k = 0;
		coinHas = PlayerPrefs.GetInt ("cc");
		if (coinHas >= coinReq) 
		{
			coinHas = coinHas - coinReq;
			PlayerPrefs.SetInt ("cc", coinHas);
			k = 1;
		}

		return k;
	}





	public void buy()
	{ int bought = 0;
		
		if (pcode == 1)
		{
			lvl = PlayerPrefs.GetInt ("JetPackLvl");

			if (lvl == 0) 
			{
				coinReq = 200;
				newTime = 7.0f;
				bought=buyReference (coinReq);
				if (bought == 1) {
					PlayerPrefs.SetFloat ("JetPackTime", newTime);
					lvl = 1;
					PlayerPrefs.SetInt ("JetPackLvl", lvl);
				}
			}
			else if (lvl == 1) 
			{
				coinReq = 500;
				newTime = 8.0f;
				bought=buyReference (coinReq);
				if (bought == 1) {
					PlayerPrefs.SetFloat ("JetPackTime", newTime);
					lvl = 2;
					PlayerPrefs.SetInt ("JetPackLvl", lvl);
				}
			}
			else if (lvl == 2) 
			{
				coinReq = 700;
				newTime = 9.0f;
				bought=buyReference (coinReq);
				if (bought == 1) {
					PlayerPrefs.SetFloat ("JetPackTime", newTime);
					lvl = 3;
					PlayerPrefs.SetInt ("JetPackLvl", lvl);
				}
			}
			else 
			{
				upgradeButton.interactable=false;
			}


		}



		if (pcode == 2)
		{
			lvl = PlayerPrefs.GetInt ("MagnetLvl");

			if (lvl == 0) 
			{
				coinReq = 200;
				newTime = 5.0f;
				bought=buyReference (coinReq);
				if (bought == 1) {
					PlayerPrefs.SetFloat ("MagnetTime", newTime);
					lvl = 1;
					PlayerPrefs.SetInt ("MagnetLvl", lvl);
				}
			}
			else if (lvl == 1) 
			{
				coinReq = 500;
				newTime = 6.0f;
				bought=buyReference (coinReq);
				if (bought == 1) {
					PlayerPrefs.SetFloat ("MagnetTime", newTime);
					lvl = 2;
					PlayerPrefs.SetInt ("MagnetLvl", lvl);
				}
			}
			else if (lvl == 2) 
			{
				coinReq = 700;
				newTime = 8.0f;
				bought=buyReference (coinReq);
				if (bought == 1) {
					PlayerPrefs.SetFloat ("MagnetTime", newTime);
					lvl = 3;
					PlayerPrefs.SetInt ("MagnetLvl", lvl);
				}
			}
			else 
			{
				upgradeButton.interactable=false;
			}


		}


		if (pcode == 3)
		{
			lvl = PlayerPrefs.GetInt ("FullCoinLvl");

			if (lvl == 0) 
			{
				coinReq = 200;
				newTime = 5.0f;
				bought=buyReference (coinReq);
				if (bought == 1) {
					PlayerPrefs.SetFloat ("FullCoinTime", newTime);
					lvl = 1;
					PlayerPrefs.SetInt ("FullCoinLvl", lvl);
				} // else show them to buy coins window 
			}
			else if (lvl == 1) 
			{
				coinReq = 500;
				newTime = 6.0f;
				bought=buyReference (coinReq);
				if (bought == 1) {
					PlayerPrefs.SetFloat ("FullCoinTime", newTime);
					lvl = 2;
					PlayerPrefs.SetInt ("FullCoinLvl", lvl);
				}
			}
			else if (lvl == 2) 
			{
				coinReq = 700;
				newTime = 8.0f;
				bought=buyReference (coinReq);
				if (bought == 1) {
					PlayerPrefs.SetFloat ("FullCoinTime", newTime);
					lvl = 3;
					PlayerPrefs.SetInt ("FullCoinLvl", lvl);
				}
			}
			else 
			{
				upgradeButton.interactable=false;
			}


		}
	}

}
