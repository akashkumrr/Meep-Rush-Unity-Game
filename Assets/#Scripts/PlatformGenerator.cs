using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;	
	public float distanceBetween;

	private float platformWidth;

	public float distanceBetweenMin;
	public float distanceBetweenMax;

	//public GameObject[] thePlatforms;
	private int platformSelector;

	private float[] platformWidths;

	[Space(20)]

	public ObjectPooler[] theObjectPools;
	public ObjectPooler[] ropedObjectPools;
	public ObjectPooler[] gravityObjectPools;
	public ObjectPooler[] nightPlatObjectPools;

	[Space(20)]
	private float minHeight;
	[Space(20)]
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;

	private CoinGenerator theCoinGenerator;
	public float randomCoinThreshold;


//	public ObjectPooler powerupPool;

	public float PowerUpHeight;
	public float PowerUpThreshold;
	//public PowerupGenerator thePowerGen;

	public PowerUpObjectPooler[] thePpools;
	public int powerUpSelector;
	public TopPowerUpManager thePMan;
	public Sprite sp1;
	public Sprite sp2;
	public Sprite sp3;
	public Sprite sp4;
	public Sprite sp5;
	public Sprite sp6;

	// for full coin powerup

	public bool FullCoin;
	public FullGenerator theFGen;

	public Vector3 CalTelepos;

	public bool ropedPlatform;
	public bool gravityPlatform;
	public bool normalPlatform;
	public bool nightPlatform;

	[Space(20)]
	public ObjectPooler[] platPurple;
	public ObjectPooler[] platConcrete;
	public ObjectPooler[] platIce;
	public ObjectPooler[] platIceB;
	public ObjectPooler[] platConcreteB;
	public ObjectPooler[] platWhiteBrown;
	public ObjectPooler[] platConcreteBrown;

	[Space(20)]
	public int missionNoAfterWhichGravityPlatsActive;

	[Space(20)]
	[Tooltip(" powerUpSelector = Random.Range (0,allUnlockedP); ")]
	public int allUnlockedP;
	public int misNo;

	[Space(10)]
	public PowerUpObjectPooler torchPool;
	public float torchPowerupThreshold;

	// Use this for initialization
	void Start () {
		/*platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;*/
	/*	int whichPlat = Random.Range (0, 4);

		if (whichPlat <= 1) {
			ropedPlatform = true;

			gravityPlatform = false;
			normalPlatform = false;
		}
		else if (whichPlat <= 2 && whichPlat > 1 && PlayerPrefs.GetInt ("missionNO") >missionNoAfterWhichGravityPlatsActive) 
		{
			gravityPlatform = true;

			ropedPlatform = false;
			normalPlatform = false;
		}
		else 
		{    // this ine is for normal platforms
			normalPlatform = true;

			ropedPlatform = false;
			gravityPlatform = false;
		}								*/



		platformWidths = new float[theObjectPools.Length];

		for (int i = 0; i < theObjectPools.Length; i++)
		{
			platformWidths[i]= theObjectPools[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
		}

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;


		theCoinGenerator = FindObjectOfType<CoinGenerator> ();



		if (PlayerPrefs.HasKey ("totalUnlockedPowerups")) {
			allUnlockedP = PlayerPrefs.GetInt ("totalUnlockedPowerups");
		} else {
			allUnlockedP = 0;
			PlayerPrefs.SetInt ("totalUnlockedPowerups", allUnlockedP);
		}
	
		//  UNLOCKS powerups according to no. of mission completed 

		if (PlayerPrefs.HasKey ("missionNO")) {
			misNo = PlayerPrefs.GetInt ("missionNO");
		} else {
			misNo = 1;
			PlayerPrefs.SetInt ("missionNO", misNo);
		}

		if (misNo < 3) {
			allUnlockedP = 0;
		} 
		else if (misNo >= 3 && misNo < 5) {
			allUnlockedP = 1;
		} 
		else if (misNo >= 5 && misNo < 9) {
			allUnlockedP = 2;
		} 
		else if (misNo >= 9 && misNo < 14) {
			allUnlockedP = 3;
		} 
		else 
		{
			allUnlockedP = 5;              //   i.e. slowering powerup as well as death powerup 
		}

		PlayerPrefs.SetInt ("totalUnlockedPowerups", allUnlockedP);



		// now change powerup frequency according to the total unlocked powerup

	/*	if (allUnlockedP == 0) 
		{
			PowerUpThreshold = 0;
		}
		else if (allUnlockedP == 1) 
		{
			PowerUpThreshold = 10;
		} 
		else if (allUnlockedP == 2) 
		{
			PowerUpThreshold = 20;
		} 
		else if (allUnlockedP == 3) 
		{
			PowerUpThreshold = 30;
		} 
		else 
		{
			PowerUpThreshold = 40;
		}
	*/


	}
	
	// Update is called once per frame
	void Update () {


	

	//	powerUpSelector = Random.Range (0, thePpools.Length);            edited 19 AUG 2018  


		powerUpSelector = Random.Range (0, allUnlockedP+1);   // genrates random integer bw (0, last) last isn't included
		powerUpSelector = powerUpSelector - 1;            //  03 november 2018

		if (transform.position.x < generationPoint.position.x) 
		{
			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			platformSelector = Random.Range (0, theObjectPools.Length);
			heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);

			if (heightChange > maxHeight) {
				heightChange = maxHeight;
			} else if (heightChange < minHeight)
			{
				heightChange = minHeight;
			}


			if (Random.Range (0f, 100f) < PowerUpThreshold) 
			{

				if (powerUpSelector >= 0)    //  because there will be no powerups for mission 1 to 3 and then the powerUpSelector will be -1;
				{
					GameObject pwrUp = thePpools [powerUpSelector].GetPooledPowerObject ();
					pwrUp.transform.position = new Vector3 (transform.position.x + 1.0f, transform.position.y + 1.0f, transform.position.z);
					pwrUp.transform.rotation = transform.rotation;
					if (powerUpSelector == 0) {
						pwrUp.GetComponent<SpriteRenderer> ().sprite = sp1;
					}
					if (powerUpSelector == 1) {
						pwrUp.GetComponent<SpriteRenderer> ().sprite = sp2;
					}
					if (powerUpSelector == 2) {
						pwrUp.GetComponent<SpriteRenderer> ().sprite = sp3;
					}
					if (powerUpSelector == 3) {
						pwrUp.GetComponent<SpriteRenderer> ().sprite = sp4;
					}
					if (powerUpSelector == 4) {
						pwrUp.GetComponent<SpriteRenderer> ().sprite = sp5;
					}


					pwrUp.SetActive (true);
				}
			
			}

			if (Random.Range (0f, 100f) < torchPowerupThreshold) 
			{
				GameObject torch = torchPool.GetPooledPowerObject ();
				torch.transform.position =new Vector3 (transform.position.x + 2.5f, transform.position.y+2.5f, transform.position.z);
				torch.transform.rotation = new Quaternion (transform.rotation.x, transform.rotation.y, transform.rotation.z - 0.26f, transform.rotation.w);

				torch.GetComponent<SpriteRenderer> ().sprite =sp6;
				torch.SetActive (true);
			}



			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector]/2) + distanceBetween, heightChange, transform.position.z);


			if (gravityPlatform == true) {
				GameObject newPlatform = gravityObjectPools [platformSelector].GetPooledObject ();
				newPlatform.transform.position = transform.position;
				newPlatform.transform.rotation = transform.rotation;
				newPlatform.SetActive (true);
			} else if (ropedPlatform == true) {


				GameObject newPlatform = ropedObjectPools [platformSelector].GetPooledObject ();
				newPlatform.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

				newPlatform.transform.rotation = transform.rotation;
				newPlatform.SetActive (true);

			} else if (normalPlatform == true) {// i.e. normal platforms
			
				GameObject newPlatform = theObjectPools [platformSelector].GetPooledObject ();
				newPlatform.transform.position = transform.position;
				newPlatform.transform.rotation = transform.rotation;
				newPlatform.SetActive (true);


			
			} else{
				

				GameObject newPlatform = nightPlatObjectPools [platformSelector].GetPooledObject ();
				newPlatform.transform.position = transform.position;
				newPlatform.transform.rotation = transform.rotation;
				newPlatform.SetActive (true);
			}




			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector]/2) , transform.position.y, transform.position.z);


			CalTelepos = new Vector3 (transform.position.x, transform.position.y + 1.0f, transform.position.z);

			if (FullCoin) 
			{
				theFGen.SpawnAllCoins (new Vector3 (transform.position.x, transform.position.y + 1.0f, transform.position.z), (int)platformWidths [platformSelector]);
			} 
			else
			{

				if (Random.Range (0f, 100f) < randomCoinThreshold)
				{
					theCoinGenerator.SpawnCoins (new Vector3 (transform.position.x, transform.position.y + 1.0f, transform.position.z),(int)platformWidths [platformSelector]); // for just placing coins above add + 1 to y position
				}
			}
		
		}
	}
}
