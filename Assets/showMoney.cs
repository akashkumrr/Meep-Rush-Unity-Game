using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class showMoney : MonoBehaviour {

	public int increaseMoney;
	public TextMeshProUGUI moneyText;

	public bool clearAllUpgradedPrefs;
	// Use this for initialization
	void Start () {
		int i;

		i = PlayerPrefs.GetInt ("cc");
		i = i + increaseMoney;
		PlayerPrefs.SetInt ("cc", i);

		if (clearAllUpgradedPrefs == true) 
		{
			PlayerPrefs.DeleteKey ("JetPackLvl");
			PlayerPrefs.DeleteKey ("JetPackTime");
			PlayerPrefs.DeleteKey ("MagnetLvl");
			PlayerPrefs.DeleteKey ("MagnetTime");
			PlayerPrefs.DeleteKey ("FullCoinLvl");
			PlayerPrefs.DeleteKey ("FullCoinTime");

		}
	}
	
	// Update is called once per frame
	void Update () {
		moneyText.text = "" + PlayerPrefs.GetInt ("cc");
	}
}
