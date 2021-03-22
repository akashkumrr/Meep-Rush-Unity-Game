using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class myAdvertShow : MonoBehaviour {


	public void ShowAd()
	{
		if (Advertisement.IsReady ()) 
		{
			Advertisement.Show ("",new ShowOptions(){resultCallback = HandleAdResult });
		}
		
	}

	private void HandleAdResult(ShowResult result)
	{
		switch (result) 
		{
		case ShowResult.Finished:
			// player gains gems
			break;
		case ShowResult.Skipped:
			// player didnt watched the full ad
			break;
		case ShowResult.Failed:
			// player wasnt able to load the ad ? internet?!
			break;


		}
	}
}
