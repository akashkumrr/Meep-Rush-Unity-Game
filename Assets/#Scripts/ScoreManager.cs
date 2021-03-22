using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	
	public Text scoreText;
	public Text hiscoreText;

	public float scoreCount;
	public float hiScoreCount;
	public float hiScoreGrav;
	public float hiScoreRope;
	public float hiScoreNight;
	[Space(10)]
	public bool gravityInfinity;
	public bool ropedInfinity;
	public bool nightInfinity;

	[Space(10)]
	public float pointsPerSecond;
	public bool scoreIncreasing;




	// Use this for initialization
	void Start () {

		/*
		if (PlayerPrefs.HasKey ("HighScore")) {
			hiScoreCount = PlayerPrefs.GetFloat ("HighScore");
		} 
		else 
		{
			hiScoreCount = 0;
			PlayerPrefs.SetFloat ("HighScore", hiScoreCount);
		}
*/
		if (gravityInfinity == true) {
			if (PlayerPrefs.HasKey ("HSGrav")) {
				hiScoreGrav = PlayerPrefs.GetFloat ("HSGrav");
			} else {
				hiScoreGrav = 0;
				PlayerPrefs.SetFloat ("HSGrav", hiScoreGrav);
			}
		}


		if (ropedInfinity == true) {
			if (PlayerPrefs.HasKey ("HSRope")) {
				hiScoreRope = PlayerPrefs.GetFloat ("HSRope");
			} else {
				hiScoreRope = 0;
				PlayerPrefs.SetFloat ("HSRope", hiScoreRope);
			}

		}

		if (nightInfinity == true) {
			if (PlayerPrefs.HasKey ("HSNight")) {
				hiScoreNight = PlayerPrefs.GetFloat ("HSNight");
			} else {
				hiScoreNight = 0;
				PlayerPrefs.SetFloat ("HSNight", hiScoreNight);
			}
		}




		scoreIncreasing = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (scoreIncreasing)
		{

			scoreCount += pointsPerSecond * Time.deltaTime;
		}

		if (scoreCount > hiScoreCount) 
		{
			hiScoreCount = scoreCount;
			PlayerPrefs.SetFloat ("HighScore", hiScoreCount);
		}

		if (gravityInfinity == true) 
		{
			if (scoreCount > hiScoreGrav) 
			{
				hiScoreGrav = scoreCount;
				PlayerPrefs.SetFloat ("HSGrav", hiScoreGrav);

			}

			hiscoreText.text = "HighScore: " + Mathf.Round((PlayerPrefs.GetFloat ("HSGrav")));

		}




		if (ropedInfinity == true) 
		{
			if (scoreCount > hiScoreRope) 
			{
				hiScoreRope = scoreCount;
				PlayerPrefs.SetFloat ("HSRope", hiScoreRope);
			}

			hiscoreText.text = "HighScore: " + Mathf.Round((PlayerPrefs.GetFloat ("HSRope")));

		}

		if (nightInfinity == true) 
		{
			if (scoreCount > hiScoreNight) 
			{
				hiScoreNight = scoreCount;
				PlayerPrefs.SetFloat ("HSNight", hiScoreNight);
			}

			hiscoreText.text = "HighScore: " + Mathf.Round((PlayerPrefs.GetFloat ("HSNight")));

		}


		scoreText.text = "Score: " + Mathf.Round(scoreCount);

	}

	public void AddScore(int pointsToAdd)
	{
		scoreCount += pointsToAdd;
	}
}
