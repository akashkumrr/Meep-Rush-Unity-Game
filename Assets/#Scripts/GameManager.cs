using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.Advertisements;


public class GameManager : MonoBehaviour {

	public Transform platformGenerator;
	private Vector3 platformStartPoint;

	public PlayerController thePlayer;
	public Vector3 playerStartPoint;

	private PlatformDestroyer[] platformList;

	private ScoreManager theScoreManager;
	public deathmenu theDeathScreen;
	public myExperiment[] myEXP;

	public bool revievd;

	public int isClicked=0;

	public powerups thePower;

	public AudioSource Aio;

	public TopPowerUpManager pwrMan;

	public GameObject Ply;
	public GameObject Cam;
	[Space(10)]
	public GameObject magnetArea;
	[Space(10)]
	public GameObject missionDeathScreen;

	[Space(10)]

	public string curSceneName;

	[Space(30)]
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
	public TextMeshProUGUI	tMeshRunMore;
	[Space(10)]
	public TextMeshProUGUI	tMeshCoinMore;
	[Space(10)]
	public TextMeshProUGUI	tMeshRanFraction;
	[Space(10)]
	public TextMeshProUGUI	tMeshCoinFraction;

	public float timeAnim;
	[Space(20)]
	[Tooltip("this affects sliders")]
	public AnimationCurve animCurve;
	[Tooltip("this affects fading values")]
	public AnimationCurve animCurve2;
	public Text misFail;

	public string myScrambleStr;

	[Space(20)]
	[Tooltip("Here enter the names of the scene you want to be played as mission")]
	public string[] sceneNames;

	[Space(20)]

	public newSoundManager theSM;
	[Space(20)]

	public GameObject platDestructionPoint;
	public float platInitialPosition;

	[Space(10)]
	public bool netActive;
	public teleportation teleScript;

	[Space(10)]
	[Tooltip("the default value of no of lives is set to 3")]
	public int noOfLives;
	public int noOfLivesStore;
	public bool inMission;
	[Space(10)]
	public GameObject[] spLivesRemaining;
	public reviveAdShow playAd;
	public GameObject promptAdWatchScr;

	public bool whetherAdWatched=true;

	[Tooltip("Only to show ad only two times and do not show third time")]
	public int timesAdWatched=1;

	// Use this for initialization
	void Start () {

		inMission = false;
		for (int q = 0; q < sceneNames.Length; ++q) {
			if (curSceneName == sceneNames [q]) {
				inMission = true;
			}
		}


		platformStartPoint = platformGenerator.position;
		playerStartPoint = thePlayer.transform.position;

		theScoreManager = FindObjectOfType<ScoreManager>();
		timesAdWatched = 1;

		Scene currentActiveScene = SceneManager.GetActiveScene ();
		curSceneName = currentActiveScene.name;


		perc = (float) ((float) 1.0f * thePC.coinCounter /floatCoinReq);
		floatCoinReq = (float)1.0f * misMan.coin;

		platInitialPosition = platDestructionPoint.transform.position.x;

	/*	if (PlayerPrefs.HasKey ("lives")) 
		{
			noOfLives = PlayerPrefs.GetInt ("lives");
		}
		else
		{
			noOfLives = 3;                                  //  change the no of lives later according to the need
			PlayerPrefs.SetInt ("lives",noOfLives);
		}
*/
		pwrMan.t1 = 0;
		pwrMan.t2 = 0;
		pwrMan.t3 = 0;

		lifeSpriteUpdate ();

	}
	
	// Update is called once per frame
	void Update () {
		

	}

	public void RestartGame()
	{
		// this is the fuction to be run after the player dies

		if ( !(Application.internetReachability == NetworkReachability.NotReachable) && (noOfLives <= 0 && (whetherAdWatched==false|| timesAdWatched>2) ) ) 
		{
			// this if block is for if the net is active but all lives gone AND display death screen if watched AD > 2 times or skipped he the AD 
			
			Debug.Log ("first if block");
			timesAdWatched = 1; // resets the no of times ad can be watched

			platDestructionPoint.transform.position = new Vector3 (transform.position.x + 100, transform.position.y, transform.position.z);

			Ply.transform.position = new Vector3 (Ply.transform.position.x, 7.0f, Ply.transform.position.z);
			Cam.transform.position = new Vector3 (Ply.transform.position.x, 1.0f, Ply.transform.position.z);
			pwrMan.t1 = 0;
			pwrMan.t2 = 0;
			pwrMan.t3 = 0;
			magnetArea.gameObject.SetActive (false);
			// the above line resets ply position and powerup status

			Time.timeScale = 1.0f;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;
			/////////	Aio.Stop ();


			thePC.upTimeStore = thePC.upTimeStore + thePC.upTime;
			PlayerPrefs.SetFloat ("playTime", thePC.upTimeStore);
			thePC.upTime = 0;
			theScoreManager.scoreIncreasing = false;
			thePlayer.gameObject.SetActive (false);
			//StartCoroutine ("RestartGameCo");

			inMission = false; 

			for (int q = 0; q < sceneNames.Length; ++q) {
				if (curSceneName == sceneNames [q]) {

					inMission = true;
				}
				
			}
			if (inMission == true) {
				//*** Get the name of the scene and then decide what to show a death screen or a mission death screen***
				missionDeathScreen.SetActive (true);

				thePC.coinCounterStore = thePC.coinCounterStore + thePC.coinCounter;
				PlayerPrefs.SetInt ("cc", thePC.coinCounterStore);



				theSM.died = true;

				coinSlider.value = 0;
				ranSlider.value = 0;


		
				coinSlider.DOValue (1.0f * thePC.coinCounter / (floatCoinReq), timeAnim, false).SetEase (animCurve);

				ranSlider.DOValue (thePC.runningDistance / misMan.run, timeAnim, false).SetEase (animCurve);


				float tempCoin;
				if (thePC.coinCounter <= floatCoinReq) {
					tempCoin = floatCoinReq - thePC.coinCounter;
				} else {
					tempCoin = 0;
				}


				float tempRun;
				if (thePC.runningDistance <= PlayerPrefs.GetFloat ("orun")) {
					tempRun = PlayerPrefs.GetFloat ("orun") - thePC.runningDistance;
				} else {
					tempRun = 0;
				}



				if (tempRun != 0) {
					tMeshRunMore.text = "Run " + ((int)(PlayerPrefs.GetFloat ("orun") - thePC.runningDistance + 1)).ToString () + " m more . . . ";
				} else {
					tMeshRunMore.text = "COMPELETED .";
				}


				if (tempCoin != 0) {
					tMeshCoinMore.text = "Collect " + (floatCoinReq - thePC.coinCounter).ToString () + " coins more . . . ";
				} else {
					tMeshCoinMore.text = "COMPELETED .";
				}


				tMeshRunMore.DOFade (0, 0.01f);
				tMeshCoinMore.DOFade (0, 0.01f);

				tMeshRunMore.DOFade (1, timeAnim + 1.0f).SetEase (animCurve2);
				tMeshCoinMore.DOFade (1, timeAnim + 1.0f).SetEase (animCurve2);


				tMeshRanFraction.text = " RUN   " + ((int)thePC.runningDistance).ToString () + " / " + ((int)PlayerPrefs.GetFloat ("orun")).ToString ();
				tMeshCoinFraction.text = " COINS   " + ((int)thePC.coinCounter).ToString () + " / " + ((int)floatCoinReq).ToString ();
		
		
		
				misFail.DOText ("Mission Failed", timeAnim, true, ScrambleMode.All, myScrambleStr);
				thePC.coinCounter = 0;
		
			} else 
			{
				Debug.Log("when not in mission");
				theDeathScreen.gameObject.SetActive (true);

				thePC.coinCounterStore = thePC.coinCounterStore + thePC.coinCounter;
				PlayerPrefs.SetInt ("cc", thePC.coinCounterStore);

				thePC.coinCounter = 0;

				theSM.died = true;
			}

			isClicked = 1;
			//	thePlayer.coinCounter=0;

		} else if (!(Application.internetReachability == NetworkReachability.NotReachable) && noOfLives <= 0&&timesAdWatched<=2)
		{  // show them ad asking them to regen the player for an AD video.
			// this if block is for if the net is active and lives gone but he can watch AD to revive


			timesAdWatched = timesAdWatched + 1;

			// _______show ad function HERE______   if button pressed revived then execute the below code


			// if ad watched then :-
			//playAd.ShowAd();               latest 8 december 2018

			promptAdWatchScr.SetActive (true);

			//teleScript.SendPlayerBackUsingAd ();

			//else copy the above part to show the coin collected and distance ran

		} else if (noOfLives > 0) {
			teleScript.SendPlayerBackUsingAd ();
			noOfLives = noOfLives - 1;                 //   because we just used one life

			lifeSpriteUpdate ();
		}
		else                                    /// BCZ else if can't end without else and also i can't think of a condition when it shld run so it is empty
		{
			// if the net is NOT active

			Debug.Log ("if lives is < 0 and net is not active");
			timesAdWatched = 1; // resets the no of times ad can be watched

			platDestructionPoint.transform.position = new Vector3 (transform.position.x + 100, transform.position.y, transform.position.z);

			Ply.transform.position = new Vector3 (Ply.transform.position.x, 7.0f, Ply.transform.position.z);
			Cam.transform.position = new Vector3 (Ply.transform.position.x, 1.0f, Ply.transform.position.z);
			pwrMan.t1 = 0;
			pwrMan.t2 = 0;
			pwrMan.t3 = 0;
			magnetArea.gameObject.SetActive (false);
			// the above line resets ply position and powerup status

			Time.timeScale = 1.0f;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;
			/////////	Aio.Stop ();
			theScoreManager.scoreIncreasing = false;
			thePlayer.gameObject.SetActive (false);
			//StartCoroutine ("RestartGameCo");

			inMission = false; 

			for (int q = 0; q < sceneNames.Length; ++q) {
				if (curSceneName == sceneNames [q]) {

					inMission = true;
				}

			}
			if (inMission == true) {
				//*** Get the name of the scene and then decide what to show a death screen or a mission death screen***
				missionDeathScreen.SetActive (true);

				thePC.coinCounterStore = thePC.coinCounterStore + thePC.coinCounter;
				PlayerPrefs.SetInt ("cc", thePC.coinCounterStore);



				theSM.died = true;

				coinSlider.value = 0;
				ranSlider.value = 0;



				coinSlider.DOValue (1.0f * thePC.coinCounter / (floatCoinReq), timeAnim, false).SetEase (animCurve);

				ranSlider.DOValue (thePC.runningDistance / misMan.run, timeAnim, false).SetEase (animCurve);


				float tempCoin;
				if (thePC.coinCounter <= floatCoinReq) {
					tempCoin = floatCoinReq - thePC.coinCounter;
				} else {
					tempCoin = 0;
				}


				float tempRun;
				if (thePC.runningDistance <= PlayerPrefs.GetFloat ("orun")) {
					tempRun = PlayerPrefs.GetFloat ("orun") - thePC.runningDistance;
				} else {
					tempRun = 0;
				}



				if (tempRun != 0) {
					tMeshRunMore.text = "Run " + ((int)(PlayerPrefs.GetFloat ("orun") - thePC.runningDistance + 1)).ToString () + " m more . . . ";
				} else {
					tMeshRunMore.text = "COMPELETED .";
				}


				if (tempCoin != 0) {
					tMeshCoinMore.text = "Collect " + (floatCoinReq - thePC.coinCounter).ToString () + " coins more . . . ";
				} else {
					tMeshCoinMore.text = "COMPELETED .";
				}


				tMeshRunMore.DOFade (0, 0.01f);
				tMeshCoinMore.DOFade (0, 0.01f);

				tMeshRunMore.DOFade (1, timeAnim + 1.0f).SetEase (animCurve2);
				tMeshCoinMore.DOFade (1, timeAnim + 1.0f).SetEase (animCurve2);


				tMeshRanFraction.text = " RUN   " + ((int)thePC.runningDistance).ToString () + " / " + ((int)PlayerPrefs.GetFloat ("orun")).ToString ();
				tMeshCoinFraction.text = " COINS   " + ((int)thePC.coinCounter).ToString () + " / " + ((int)floatCoinReq).ToString ();



				misFail.DOText ("Mission Failed", timeAnim, true, ScrambleMode.All, myScrambleStr);

				thePC.coinCounter = 0;

			} else {
				Debug.Log("when not in mission");
				theDeathScreen.gameObject.SetActive (true);

				thePC.coinCounterStore = thePC.coinCounterStore + thePC.coinCounter;
				PlayerPrefs.SetInt ("cc", thePC.coinCounterStore);

				thePC.coinCounter = 0;
				theSM.died = true;
			}

			isClicked = 1;
			//	thePlayer.coinCounter=0;
		}


	}

	public void Reset()
	{
		whetherAdWatched = true;

		// when the player restarts the game


		initialLives ();
		lifeSpriteUpdate();

		platDestructionPoint.transform.position = new Vector3 (platInitialPosition, transform.position.y, transform.position.z);
		// above : for fixing the too much spwaning of powerups when dying at starting


		theSM.died = false;
		theSM.completed= false;
		theSM.BGM.clip = theSM.bgMusicClip;
		theSM.BGM.Play ();



		revievd = true;
		if (pwrMan.t2 > 0)
		{Ply.transform.position=new Vector3 (Ply.transform.position.x, 7.0f , Ply.transform.position.z);
			Cam.transform.position =new Vector3 (Ply.transform.position.x, 1.0f , Ply.transform.position.z);
			pwrMan.t2 = 0;
		}
	////////	Aio.Play ();
		theDeathScreen.gameObject.SetActive (false);
		missionDeathScreen.SetActive (false);
		platformList = FindObjectsOfType<PlatformDestroyer> ();
		for (int i = 0; i < platformList.Length; i++)
		{
			platformList [i].gameObject.SetActive (false);
		}
		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true);

		theScoreManager.scoreCount = 0;
		theScoreManager.scoreText.text = "0";
		theScoreManager.scoreIncreasing = true;
		for (int i = 0; i < 10; ++i) {
			myEXP[i].num = 0;


		}
		isClicked = 0;
		thePlayer.coinCounter=0;
		thePower.doublePoints = false;
		revievd =false;
	}


	public void lifeSpriteUpdate()
	{
		
		if (noOfLives == 3) 
		{
			spLivesRemaining [0].SetActive (true);
			spLivesRemaining [1].SetActive (true);
			spLivesRemaining [2].SetActive (true);
		}

		if (noOfLives == 2) 
		{
			spLivesRemaining [0].SetActive (true);
			spLivesRemaining [1].SetActive (true);
			spLivesRemaining [2].SetActive (false);
		}

		if (noOfLives == 1) 
		{
			spLivesRemaining [0].SetActive (true);
			spLivesRemaining [1].SetActive (false);
			spLivesRemaining [2].SetActive (false);
		}

		if (noOfLives == 0) 
		{
			spLivesRemaining [0].SetActive (false);
			spLivesRemaining [1].SetActive (false);
			spLivesRemaining [2].SetActive (false);
		}
		
	}

	public void initialLives()
	{
		noOfLives = noOfLivesStore;	
	}



}
