using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public string mainMenuLevel;

	public AudioSource mymusic;
	public Slider myslide;

	public GameObject pauseMenu;
	//public int wtf=0;
	public GameManager gaman;
	public myExperiment[] sez;




	void Start () {
		if (PlayerPrefs.HasKey("vol"))
		{
			myslide.value = PlayerPrefs.GetFloat ("vol");
		}

	
	}





	public void PauseGame(){
		Time.timeScale = 0.0f;
		pauseMenu.SetActive (true);


	}

	public void ResumeGame(){
		Time.timeScale = 1f;

		pauseMenu.SetActive (false);

		//wtf = 0;
	}  


	public void RestartGame()
	{  

		Time.timeScale = 1f;
		pauseMenu.SetActive (false);

		FindObjectOfType<GameManager> ().Reset();

	}

	public void QuitToMain()
	{Time.timeScale = 1f;
		//wtf = 1;
		SceneManager.LoadScene("MainMenu");
		//Application.LoadLevel (mainMenuLevel);
	}

	void Update () {
		
	//	mymusic.volume = myslide.value;
	//	PlayerPrefs.SetFloat ("vol", myslide.value);


	}
}
