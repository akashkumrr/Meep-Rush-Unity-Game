using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class BuyObj : MonoBehaviour {

	public bool coin;
	public bool coinObjComp;
	public TextMeshProUGUI coinText;
	public Slider coinSlider;
	public int coinReq;

	[Space(10)]
	public bool run;
	public bool runObjComp;
	public TextMeshProUGUI runText;
	public Slider runSlider;
	public int runReq;


	[Space(10)]
	public bool tm;
	public bool tmObjComp;
	public TextMeshProUGUI tmText;
	public Slider tmSlider;
	public int tmReq;


	[Space(10)]
	public bool scr;
	public bool scrObjComp;
	public TextMeshProUGUI scrText;
	public Slider scrSlider;
	public int scrReq;



	[Space(10)]

	public int obj=0,oc=0;

	public GameObject playerBuyButton;

	public Button buyBut;
	public Button equipBut;

	public int pID;


	public int i=0;


	public float runVar;
	public int coinVar;

	public float timeVar;



	public int t1;
	public float q1;
	[Space(10)]

	public int t2;
	public float q2;
	[Space(10)]
	public int t3;
	public float q3;
	[Space(10)]
	public int t4;
	public float q4;
	[Space(10)]


	public GameObject equipImg;

	[Space(10)]

	public string whatIsInUidPlaayerPref;

	[Space(10)]
	public AnimationCurve curve;

	[Space(10)]
	[Tooltip("this is the time taken by the sliders t get filled")]
	public float sldAnimTm;
	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame

	void Update () {
		runVar = Mathf.Round (PlayerPrefs.GetFloat ("rd"));
		coinVar =  PlayerPrefs.GetInt ("cc");
		timeVar= Mathf.Round(PlayerPrefs.GetFloat ("playTime"));

		whatIsInUidPlaayerPref =PlayerPrefs.GetInt ("uid").ToString();


		if (PlayerPrefs.GetInt ("uid") == pID) {
			equipImg.SetActive (true);
		} else {
			equipImg.SetActive (false);
		}
	}

	public void CountObj()
	{   
		if (coin == true) 
		{t1 = PlayerPrefs.GetInt ("cc"); //    Use TypeCast to Get Answer in Float
			q1 = (float)t1 / coinReq;

			coinText.text = "Coins : " + coinReq;
			if (PlayerPrefs.GetInt ("cc") > coinReq) 
			{
				q1 = 1;
				
				coinObjComp = true;
				coinSlider.value = q1;
			}
			else
			{coinSlider.value =q1;
				
			}

		}
		else 
		{
			coinSlider.gameObject.SetActive(false);
		}


		if (run == true) 
		{t2 = PlayerPrefs.GetInt ("rd"); //    Use TypeCast to Get Answer in Float
			q2 = (float)t2 / runReq;
			runText.text = "Run " + runReq;//+ " meters";		

			if (PlayerPrefs.GetFloat ("rd") > runReq) 
			{q2 = 1;


				runObjComp = true;
				runSlider.value = q2;
			} 
			else 
			{runSlider.value = q2;
			}
		} 
		else 
		{
			runSlider.gameObject.SetActive(false);
		}


		if (tm == true) 
		{
			t3 = (int)PlayerPrefs.GetFloat("PlayTime"); //    Use TypeCast to Get Answer in Float
			q3 = (float)t3 / tmReq;

			tmText.text = "Play for " + tmReq;
			if (PlayerPrefs.GetFloat ("playTime") > tmReq) 
			{
				q3 = 1;

				tmSlider.value = q3;
				tmObjComp = true;
			} else 
			  {tmSlider.value = q3;
			   }
		}
		else 
		{
			tmSlider.gameObject.SetActive(false);
		}

		if (scr == true) 
		{t4 = (int)PlayerPrefs.GetFloat("HighScore"); //    Use TypeCast to Get Answer in Float
			q4 = (float)t4 / scrReq;
			scrText.text = "Reach a score of " + scrReq;
			if (PlayerPrefs.GetFloat ("HighScore") > scrReq) 
			{
				q4 = 1;

				scrSlider.value = q4;
				scrObjComp = true;
			} else 
			  {scrSlider.value = q4;}
		}
		else 
		{
			scrSlider.gameObject.SetActive(false);
		}




	}

	public void ToActivateButton()
	{
		if (coin == true) 
		{
			obj++;
			if (coinObjComp == true) 
			{
				oc++;
			}
		}


		if (run == true) 
		{
			obj++;
			if(runObjComp==true)
			{
				oc++;
			}
		}

		if(tm==true)
		{
			obj++;
			if (tmObjComp == true) 
			{
				oc++;
			}
		}

		if (scr == true) 
		{
			obj++;
			if (scrObjComp == true) {
				oc++;
			}
		}






		if (obj == oc && oc != 0)
		{
			playerBuyButton.SetActive (true);

			for (i = 1; i <= 5; ++i)
			{
				if (i == pID) 
				{	
					if (PlayerPrefs.HasKey ("p2" + i))
					{
						equipBut.interactable = true;
						buyBut.interactable = false;


					}
					else 
					{
						equipBut.interactable = false;

					}
				}
			}

		} 
		else 
		{
			playerBuyButton.SetActive (false);
			equipBut.interactable = false;

		}

	}

	public void BuyPlayerButton()
	{
		for (i = 1; i <= 5; ++i) 
		{
			
//		/*
			if (i == pID) {
				if (!PlayerPrefs.HasKey ("p2" + i)) 
				{
					if (PlayerPrefs.GetInt ("cc") > coinReq) {   //    coinObj == true ensures this but it won't run/update at time required
						PlayerPrefs.SetInt ("cc", PlayerPrefs.GetInt ("cc") - coinReq);
						buyBut.interactable = false;
						PlayerPrefs.SetInt ("p2" + i, pID);
					}
				}
			}



			
	
	
		}
	}

	public void ClearPrefs()
	{// this clears prefs for pressed buying buttons
		for (i = 1; i <= 5; ++i) {
			PlayerPrefs.DeleteKey ("p2" + i);
		}
			
	}



	public void SelectPlayer()
	{
		//  buy toh kar le pehle 
		if (buyBut.interactable == false) 
		{
			PlayerPrefs.SetInt ("uid", pID);
		}
	}


	public void EaseOutAllSliders()
	{
		coinSlider.value = 0;  //// q1 value to be assigned

		runSlider.value = 0;   //// q2 

		tmSlider.value = 0;    //// q3

		scrSlider.value = 0;   //// q4

		if (coin == true) {
			coinSlider.DOValue (q1, sldAnimTm, false).SetEase (curve);
		}

		if (run == true) {
			runSlider.DOValue (q2, sldAnimTm, false).SetEase (curve);
		
		}
		if (tm == true) {
			tmSlider.DOValue (q3, sldAnimTm, false).SetEase (curve);
		}

		if (scr == true) {
			scrSlider.DOValue (q4, sldAnimTm, false).SetEase (curve);
		}



	}


	public void ClearMissions()
	{
		PlayerPrefs.DeleteKey ("missionNO");
	}




}
