using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour {

	public GameObject objScreen;
	public GameObject perkObjScreen;
	public PlayerController thePC;

	[Tooltip("This is used to denote mission no")]
	public int i;

	// scrap objective selector script and use it here

	[Space(10)]
	public int coin;
	public int run;
	[Space(10)]

	public float runLeft;
	public int coinLeft;


	private bool missionComplete;

	public GameObject missionCompleteScreen;

	public int obj=0,oc=0;

	public bool neverDone=false;
	public bool neverDone2=false;
	public bool neverDone3=false;


	public bool clearMissionPref;

	public ScoreManager scrMan;
	[Space(10)]

	public newSoundManager theSM;
	[Space(10)]

	public TopPowerUpManager pwrMan;
	public bool netActive;
	public bool playedAd;

	[Space(10)]
	[Tooltip(" if(Random.Range(0,10)>perkMenuFreq) ")]
	public float perkMenuFreq;
	public perkAdShow pAd;

	[Space(10)]
	[Tooltip("the jump sound audio source's volume is set to be 0 in starting(in script ply controller) if playing mission mode. SO on pressing play button jump sound.volume shld be setted")] 
	public AudioSource jumpAudioSource;
	public GameManager gMan;
	// Use this for initialization
	void Start () {

		jumpAudioSource.mute=true;

			scrMan.scoreIncreasing = false;

			if (clearMissionPref == true) {			
				PlayerPrefs.DeleteKey ("missionNO");
			}

			neverDone = false;
			neverDone2 = false;
			neverDone3 = false;

		// randomise to show the perk obj screen or simple obj screen

		if (Random.Range (0, 10) > perkMenuFreq)            //  in order to do this both screen should be already in disabled state i.e. not active
		{
			perkObjScreen.SetActive (true);
		} 
		else 
		{
			objScreen.SetActive (true);
		}

		thePC.moveSpeed = 0;


			if (PlayerPrefs.HasKey ("missionNO")) {
				i = PlayerPrefs.GetInt ("missionNO");
			} else {
				i = 1;
				PlayerPrefs.SetInt ("missionNO", i);
			}

/*			coin = 0;
			run = 0;

			if (i >= 1 && i <= 5) {      //    this tells that mission 1 to 5 is about running 500 metres
				run = 100;
				coin = 20;
			}

			if (i > 5 && i <= 10) {
				run = 200;
				coin = 25;
			}

			if (i > 10 && i <= 15) {
				run = 300;
				coin = 30;
			}

			if (i > 15 && i <= 20) {
				run = 350;
				coin = 33;
			}				*/

			PlayerPrefs.SetFloat ("orun", run);
			PlayerPrefs.SetInt ("ocoin", coin);


			if (run != 0) {
				obj++;
			}

			if (coin != 0) {
				obj++;
			}


		if(netActive==true) 
		{
			// show them ad asking them to add an powerup for an AD video.


			// _______show ad function HERE______   if button pressed then execute the below code


			// if ad watched then :-

			// playedAd=yes

		}
	}
	
	// Update is called once per frame
	void Update () {


		if (run!=0) 
		{
			runLeft = run - thePC.runningDistance;

		}

		if (runLeft <= 0&&neverDone==false) 
		{
			oc++;
			neverDone = true;
			//missionComplete = true;	
		}



		if (coin!=0) {
			coinLeft = coin - thePC.coinCounter;

			
		}

		if(coinLeft<=0&&neverDone2==false)
		{
			oc++;
			neverDone2 = true;
			//missionComplete = true;	
		}

		if (obj==oc&&neverDone3==false) 
		{ int j;

			neverDone3 = true;

			thePC.moveSpeed = 0;
			thePC.plyGameObj.SetActive (false);

			missionComplete = true;
			scrMan.scoreIncreasing = false;

			missionCompleteScreen.SetActive (true);
			theSM.completed = true;

			j = PlayerPrefs.GetInt ("missionNO")+1;
			PlayerPrefs.SetInt("missionNO",j);
		}


		
	}



	public void PlayMission()
	{
		Time.timeScale = 1.0f;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;

		perkObjScreen.SetActive (false);
		objScreen.SetActive (false);
		thePC.moveSpeed = 10;
		scrMan.scoreIncreasing = true;

		jumpAudioSource.mute=false;


		if (pAd.pwrRandomSelectorVariable >= 0 && pAd.pwrRandomSelectorVariable <= 2) 
		{
			pwrMan.t1 = PlayerPrefs.GetFloat ("MagnetTime");
		}

		if (pAd.pwrRandomSelectorVariable > 2 && pAd.pwrRandomSelectorVariable <= 4) 
		{
			pwrMan.t2=PlayerPrefs.GetFloat ("JetPackTime");
		}

		if (pAd.pwrRandomSelectorVariable > 4 && pAd.pwrRandomSelectorVariable <= 8) 
		{
			pwrMan.t3= PlayerPrefs.GetFloat ("FullCoinTime");

		}


		if (pAd.pwrRandomSelectorVariable > 8 && pAd.pwrRandomSelectorVariable <= 10) 
		{
			gMan.noOfLives = gMan.noOfLives + 1;
		}


		if (playedAd == true)    //then :-        here they need to be placed as the timer started before we pressed the play button
		{ 
			if (Random.Range (1, 3) >= 2) {
				pwrMan.t1 = PlayerPrefs.GetFloat ("MagnetTime");
			} else {
				pwrMan.t3 = PlayerPrefs.GetFloat ("FullCoinTime");
			}
		}
	}


}
