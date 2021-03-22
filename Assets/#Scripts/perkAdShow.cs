using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using TMPro;
using DG.Tweening;

public class perkAdShow : MonoBehaviour {


	public TextMeshProUGUI alreadyText;
	public bool watchedOnceAd=false; 


	[Space(10)]
	public float pwrRandomSelectorVariable;


	public GameObject[] pwrupReferenceImages;

	[Tooltip("this will show : you've got magnet powerup/ jetPOwerup or extra life")]
	public TextMeshProUGUI textAdSuccessPwrup; 

	public Image img;
	public Image img2;

	[Space(10)]
	public AudioSource gotPwrupSound;

	public AnimationClip barAnim;
	public Animation aniComponent;


	void Start () {

	}

	void Update() 
	{
		 	
	}



	public void ShowAd()
	{   
		

		//alreadyText.CrossFadeAlpha(100f, 0f, true);


		
		if (watchedOnceAd == false) {
			if (Advertisement.IsReady ()) {
				Advertisement.Show ("", new ShowOptions (){ resultCallback = HandleAdResult });
			}
		} 
		else 
		{  
			alWatched ();
		}

	}



	public void alWatched()
	{
		StartCoroutine (qw ());
	}

	IEnumerator qw()
	{
		img.gameObject.SetActive (true);
		yield return new WaitForSeconds (3); 
		alreadyText.CrossFadeAlpha (0f, 2f, true);
		img.gameObject.SetActive (false);
	}

	private void HandleAdResult(ShowResult result)
	{
		switch (result) 
		{
		case ShowResult.Finished:
			
			watchedOnceAd = true;
			aniComponent.clip = barAnim;
			aniComponent.Play (); 
			gotPwrupSound.Play ();

			pwrRandomSelectorVariable = Random.Range (0, 10);    // i.e. including 0 to 9.9999 ( excluding 10)

			img2.DOFade (100f, 0.1f);

			if (pwrRandomSelectorVariable >= 0 && pwrRandomSelectorVariable <= 2) 
			{
				pwrupReferenceImages [0].SetActive (true);
				pwrupReferenceImages [1].SetActive (false);
				pwrupReferenceImages [2].SetActive (false);
				pwrupReferenceImages [3].SetActive (false);

				textAdSuccessPwrup.text = "PERK : MAGNET !!!";
			
			}

			if (pwrRandomSelectorVariable >2 && pwrRandomSelectorVariable <=4) 
			{
				pwrupReferenceImages [0].SetActive (false);
				pwrupReferenceImages [1].SetActive (true);
				pwrupReferenceImages [2].SetActive (false);
				pwrupReferenceImages [3].SetActive (false);

				textAdSuccessPwrup.text = "PERK : JET !!!";
			
			}

			if (pwrRandomSelectorVariable >4&& pwrRandomSelectorVariable <=8) 
			{
				pwrupReferenceImages [0].SetActive (false);
				pwrupReferenceImages [1].SetActive (false);
				pwrupReferenceImages [2].SetActive (true);
				pwrupReferenceImages [3].SetActive (false);

				textAdSuccessPwrup.text = "PERK : COIN BOOM !!!";
			
			}

			if (pwrRandomSelectorVariable >8&& pwrRandomSelectorVariable <=10) 
			{	pwrupReferenceImages [0].SetActive (false);
				pwrupReferenceImages [1].SetActive (false);
				pwrupReferenceImages [2].SetActive (false);
				pwrupReferenceImages [3].SetActive (true);

				textAdSuccessPwrup.text = "PERK : EXTRA LIFE !!!";
			
			}

		


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
