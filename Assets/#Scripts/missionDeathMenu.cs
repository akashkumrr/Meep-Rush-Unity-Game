using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class missionDeathMenu : MonoBehaviour {

	public Slider ranSlider;
	public Slider coinSlider;

	public PlayerController thePC;

	public MissionManager misMan;

	[Space(10)]

	public float perc;

	[Space(10)]
	public float floatCoinReq;

	[Space(10)]
	[Tooltip("this mission death scr is activated in the game manager script")]
	public GameObject misDeathScr;

	[Space(10)]
	public TextMeshProUGUI	tMeshRan;
	[Space(10)]
	public TextMeshProUGUI	tMeshCoinCollected;

	public float x;
	// Use this for initialization
	void Start () {

		perc = (float) ((float) 1.0f * thePC.coinCounter /floatCoinReq);
		floatCoinReq = (float)1.0f * PlayerPrefs.GetInt ("ocoin");
////mthd 1		coinSlider.maxValue = PlayerPrefs.GetInt ("ocoin");
	}
	
	// Update is called once per frame
	void Update () {




		if (!misDeathScr.activeInHierarchy) 
		{
			coinSlider.value = 0;
			ranSlider.value = 0;
			x = 0;
		} 
		else // this maybe causing overheads as it is in update but is used when dies so place it in ply control oncollision deathbox function
		{	
			

			if (coinSlider.value <= 1.0f * (1.0f * thePC.coinCounter / floatCoinReq)) 
			{
				coinSlider.value += 0.01f;
			}


			if (ranSlider.value <= thePC.runningDistance / PlayerPrefs.GetFloat ("orun")) 
			{
				ranSlider.value += 0.01f;
			}

			}
	}
}
