using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {






	private int i;
	public string[] levelName;
	[Space(10)]

	[Tooltip("total LvlNames will tell us how many level NAMES we will have P.S. this is different from total level DEFAULT 3")]
	public int totalLvlNames=3;


	// Use this for initialization
	void Start () {

		if (PlayerPrefs.HasKey ("missionNO")) {
			i = PlayerPrefs.GetInt ("missionNO");
		} 
		else 
		{
			i = 1;
			PlayerPrefs.SetInt ("missionNO", i);
		}



	//	levelName = new string[totalLvlNames]; this is causing problem as u cannot initiallise this , it creates new empty array of vars
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void lvlSelector()
	{
		Time.timeScale = 1.0f;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;

		i = PlayerPrefs.GetInt ("missionNO"); 



		int j = 0;

		for (j = 1; j <= 20; ++j) 
		{
			if (i == j) 
			{
				SceneManager.LoadScene(levelName[j-1]);
			}
		}


		if (i >= 21) 
		{
			this.gameObject.SetActive (false);
		}


	}

	public string whatMissionLevel()
	{
		i = PlayerPrefs.GetInt ("missionNO"); 


		int j = 0;

		for (j = 1; j <= 20; ++j) 
		{
			if (i == j) 
			{
				return levelName [j - 1];
			}
		}

		return null;
	}
}
