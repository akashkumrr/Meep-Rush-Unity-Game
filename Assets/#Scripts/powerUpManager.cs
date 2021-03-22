using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpManager : MonoBehaviour {


	private bool doublePoints;

	private bool powerupActive;

	private float powerupLengthCounter;

	private ScoreManager theScoreManager;

	//private PlatformGenerator thePlatformGenerator;

	private float normalPoints;

	public int ptsMultipiler;

	public bool shldDouble;

	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();
	//	thePlatformGenerator = FindObjectOfType<PlatformGenerator> ();
		shldDouble = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (powerupActive) 
		{
			powerupLengthCounter -= Time.deltaTime;

			if (doublePoints&&shldDouble) 
			{
				theScoreManager.pointsPerSecond = normalPoints *ptsMultipiler;
			}


			if (powerupLengthCounter <= 0) {
				theScoreManager.pointsPerSecond = normalPoints;
				powerupActive = false;

			} 
			else 
			{shldDouble = false;
			}
		
		}

		
	}

	public void ActivatePowerup(bool points,float time)
	{shldDouble = true;
		doublePoints = points;
		powerupLengthCounter = time;

		normalPoints = theScoreManager.pointsPerSecond;
		powerupActive = true;
	}
}
