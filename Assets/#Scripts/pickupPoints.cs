using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


public class pickupPoints : MonoBehaviour {

	public int scoreToGive;
	public int oneCoin = 1;
	private ScoreManager theScoreManager;
	[Space(10)]
	public Text myCoinText;
	public RectTransform txtRect;
	public AnimationCurve curv;
	[Space(10)]
	private AudioSource coinSound;
	//public int cnt = 0;
	public PlayerController thewhole;

	public Vector3 finalSizeofTextAnimated;

	public TextMeshProUGUI coinProText;


	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();

		coinSound = GameObject.Find ("CoinSound").GetComponent<AudioSource> ();

		coinProText.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		coinProText.text ="" + thewhole.coinCounter;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") 
		{ 
			txtRect.DOScale (new Vector3 (1, 1,1), 0.001f);
			thewhole.coinCounter = thewhole.coinCounter+ 1;
		//	thewhole.Addcoin(oneCoin);
			theScoreManager.AddScore (scoreToGive);
			gameObject.SetActive (false);
			if (coinSound.isPlaying) 
			{
				coinSound.Stop ();
				coinSound.Play ();
			} 
			else 
			{coinSound.Play ();}
		
			txtRect.DOScale (new Vector3 (1.5f, 3 , 2), 0.2f).SetEase(curv);


		}
		//cnt++;;

	
	}
}
