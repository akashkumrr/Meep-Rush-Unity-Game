using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScenes : MonoBehaviour {


	/*public GameObject loadingScreen;
	public Slider slider;
	public Text progressText;

*/


	private int i;
	public LevelSelector lSelect;




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




	IEnumerator LoadAsynchronously(string sceneName)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneName);


		//loadingScreen.SetActive (true);

		while (!operation.isDone) 
		{
			float progress = Mathf.Clamp01 (operation.progress / .9f);
		//	slider.value = progress;
		//	progressText.text = Mathf.Round(progress* 100f) + "%";

			yield return null;
		}

	}

	public void chooseLvl()
	{


		i = PlayerPrefs.GetInt ("missionNO"); 



		int j = 0;

		for (j = 1; j <= 20; ++j) 
		{
			if (i == j) 
			{				
				//SceneManager.LoadScene(levelName[j-1]);

				StartCoroutine (LoadAsynchronously (lSelect.whatMissionLevel() ) );

			}

		}
	}





}
