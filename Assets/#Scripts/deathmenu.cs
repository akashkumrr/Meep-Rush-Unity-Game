using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathmenu : MonoBehaviour {



	public void RestartGame()
	{
		
		FindObjectOfType<GameManager> ().Reset();

	}

	public void QuitToMain()
	{
		SceneManager.LoadScene("MainMenu");
		//Application.LoadLevel (mainMenuLevel);
	}

}
