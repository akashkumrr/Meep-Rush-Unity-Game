using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class powerups : MonoBehaviour {



	public bool doublePoints;

	//// private powerUpManager thePowerupManager;

	public float powerupLength;

	public TopPowerUpManager PowMan;

	public int PowerUpTypeInt;

	public GameObject PlyPos;
	public GameObject CamPos;

	[Space(10)]
	public RectTransform sldrRect;
	public AnimationCurve curv;

	[Space(10)]
	public PlayerController thePC;
	public GameManager theGMan;
	public AudioSource powerupSound;

	// Use this for initialization
	void Start () {

		PowMan= FindObjectOfType<TopPowerUpManager> ();

		if (PowerUpTypeInt == 1)
		{
			powerupLength = PlayerPrefs.GetFloat ("MagnetTime");
		}

		if (PowerUpTypeInt == 2) 
		{	
			powerupLength = PlayerPrefs.GetFloat ("JetPackTime");
		}


		if (PowerUpTypeInt ==3 )
		{
			powerupLength = PlayerPrefs.GetFloat ("FullCoinTime");
		}
				
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player"&&other.gameObject.tag=="Player")
		{

			if (powerupSound.isPlaying) 
			{
				powerupSound.Stop ();
				powerupSound.Play ();
			} 
			else 
			{powerupSound.Play ();}


			sldrRect.DOScale (new Vector3 (1, 1,1), 0.001f);

			
			if (PowerUpTypeInt == 2) 
			{
				PlyPos.transform.position=new Vector3 (PlyPos.transform.position.x,PlyPos.transform.position.y+200,PlyPos.transform.position.z);
				PlyPos.GetComponent<Rigidbody2D> ().gravityScale = 5;
				CamPos.transform.position=new Vector3 (CamPos.transform.position.x,CamPos.transform.position.y+200,CamPos.transform.position.z);
			
			}

			if (PowerUpTypeInt == 69) 
			{
				thePC.moveSpeed = thePC.moveSpeed / thePC.speedMultiplier;
			}

			if (PowerUpTypeInt == 10) 
			{
				theGMan.noOfLives = theGMan.noOfLives-1;

				theGMan.lifeSpriteUpdate ();

				if (theGMan.noOfLives < 0) 
				{
					theGMan.RestartGame ();
				}
			}

			sldrRect.DOScale (new Vector3 (2, 2, 2), 0.2f);
			sldrRect.DOScale (new Vector3 (1.6f, 1.6f, 2), 0.2f).SetEase(curv);


		//	thePowerupManager.ActivatePowerup (doublePoints, powerupLength);
			PowMan.ActivatePowerup(PowerUpTypeInt,powerupLength);

			gameObject.GetComponent<SpriteRenderer>().sprite=null;
		}	
	}


}
