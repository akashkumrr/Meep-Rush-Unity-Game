using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MissionText : MonoBehaviour {

	public TextMeshProUGUI	missionNameText;
	public TextMeshProUGUI	missionRunText;
	public TextMeshProUGUI	missionCoinText;
	[Space(10)]
	public TextMeshProUGUI	missionNameTextA;
	public TextMeshProUGUI	missionRunTextA;
	public TextMeshProUGUI	missionCoinTextA;
	[Space(10)]
	public TextMeshProUGUI	tMeshRunLeft;
	public TextMeshProUGUI	tMeshCoinLeft;
	[Space(10)]
	public MissionManager misMan;


	// Use this for initialization
	void Start () {
		////TextMeshProUGUI	tMesh=GetComponent<TextMeshProUGUI> ();
		//tMesh.text = "This is a sample test text";



		missionRunText.text = "RUN " + misMan.run.ToString () + " Meters";

		missionCoinText.text = "COLLECT " + misMan.coin.ToString () + " Coins";

		missionRunTextA.text = "RUN " + misMan.run.ToString () + " Meters";

		missionCoinTextA.text = "COLLECT " + misMan.coin.ToString () + " Coins";
	}
	
	// Update is called once per frame
	void Update () {
		missionNameText.text="Mission no."+misMan.i.ToString();  // cuz this has to be initilised in other script so this has to be after START function

		missionNameTextA.text="Mission no."+misMan.i.ToString();

		int intRunLeft = (int)misMan.runLeft;

		if (intRunLeft >= 0) {
			tMeshRunLeft.text = "Run " + intRunLeft.ToString () + " m";
		}

		if (misMan.coinLeft >= 0)
		{
			tMeshCoinLeft.text = "Coin Remaining " + misMan.coinLeft;
		}
	}



}
