using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupThreshEndless : MonoBehaviour {

	public int powerupsUnlockedForEndless;
	public PlatformGenerator pGen;

	// Use this for initialization
	void Start () {
		powerupsUnlockedForEndless = PlayerPrefs.GetInt ("totalUnlockedPowerups");

		if (powerupsUnlockedForEndless <= 2) {
			pGen.PowerUpThreshold = 30.0f;
		} 
		else 
		{
			pGen.PowerUpThreshold = 50.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
