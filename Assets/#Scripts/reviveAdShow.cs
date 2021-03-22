using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using TMPro;

public class reviveAdShow : MonoBehaviour {

	public teleportation teleScript;
	public GameManager gMan;
	public PlayerController thePC;
	public ScoreManager theSMan;
	public GameObject player;
	public TextMeshProUGUI coinProText;

	[Space(10)]
	public AnimationClip heartAnimClip;
	public Animation aniComponentOfGameobject;
	public GameObject adPromptPanel;
	public adPromptWatchScreen adPromptWatchScr;
	public AudioSource reviveSound;

	public void ShowAd()
	{	
		player.SetActive (false);

		theSMan.scoreIncreasing = false;



		if (Advertisement.IsReady ()) {
			
			Advertisement.Show ("", new ShowOptions (){ resultCallback = HandleAdResult });
		} 


	}

	private void HandleAdResult(ShowResult result)
	{adPromptWatchScr.t1 = 1000;
		switch (result) 
		{
		case ShowResult.Finished:			


			aniComponentOfGameobject.clip = heartAnimClip;
			aniComponentOfGameobject.Play ();

			player.SetActive (true);
			teleScript.SendPlayerBackUsingAd ();
			thePC.moveSpeed = thePC.moveSpeedStore;
			theSMan.scoreIncreasing = true;
			adPromptWatchScr.t1 = 5;
			reviveSound.Play ();
			adPromptPanel.SetActive (false);


			// player gains gems
			break;
		case ShowResult.Skipped:
									coinProText.text = "0";
									gMan.whetherAdWatched = false;
									gMan.RestartGame ();
			adPromptWatchScr.t1 = 5;
			adPromptPanel.SetActive (false);

			// player didnt watched the full ad
			break;
		case ShowResult.Failed:     

			// player wasnt able to load the ad ? internet?!
			break;


		}
	}
}
