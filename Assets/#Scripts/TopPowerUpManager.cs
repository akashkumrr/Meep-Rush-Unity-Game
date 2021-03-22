using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TopPowerUpManager : MonoBehaviour {


	public float PowLen;
	public int PowType;

	public float t1;
	public float t2;
	public float t3;
//	public float t4;
//	public float t5;

	public int temp;


	public PlayerController thePC;
	public PlatformGenerator thePgen;

	public Slider jetpackSlider;
	public Slider magnetSlider;
	public Slider fullcoinSlider;

	//public Transform NormPos;
	public GameObject PlPos;
	public GameObject CPos;

	public float thrust;

	[Tooltip("Just a reference to gameobject which controls magnetic area")]
	public GameObject magnetArea;

	[Tooltip("this is adjust the frequency of sine wave of coins")]
	public int cnt=0;

	[Tooltip("this is reference to the script which generates sine wave of coins")]
	public sineGenCoin sgc;

	public string str1;

	private float jetMaxTime;
	private float magMaxTime;
	private float fullMaxTime;

	[Space(10)]
	public RectTransform mgtSldrRectTransform;
	public RectTransform jetSldrRectTransform;
	public RectTransform fullSldrRectTransform;

	[Space(10)]
	public float mgtPosYStore;
	public float jetPosYStore;
	public float fullPosYStore;

	[Space(10)]
	public float animatingOrTweeningTime;
	[Space(10)]
	public AnimationCurve curv;

	// Use this for initialization
	void Start () {
		
		magMaxTime = PlayerPrefs.GetFloat ("MagnetTime");


		jetMaxTime = PlayerPrefs.GetFloat ("JetPackTime");

		fullMaxTime = PlayerPrefs.GetFloat ("FullCoinTime");

	}
	
	// Update is called once per frame
	void Update () {




		if (t1 > 0) {
			temp = PowType;
			PowType = 1;
		} 
		else
		{//// so make else statement like this for every time i.e. t2 and t3 and paste code here too
			//jetSldrRectTransform.DOMoveY (mgtPosYStore, animatingOrTweeningTime, false).SetEase(curv);

			//jetSldrRectTransform.anchoredPosition= new Vector2(-493, mgtPosYStore);  // this one is working right do like this for others too
		
			if (t2 > 0) 
			{
				jetSldrRectTransform.DOAnchorPosY(mgtPosYStore, animatingOrTweeningTime, false).SetEase(curv);


				fullSldrRectTransform.DOAnchorPosY(jetPosYStore, animatingOrTweeningTime, false).SetEase(curv);
			}
			else 
			{
				fullSldrRectTransform.DOAnchorPosY(mgtPosYStore, animatingOrTweeningTime, false).SetEase(curv);
			}

		}
		if (PowType == 1)
		{t1 -= Time.deltaTime;
			if (t1 > 0) {
				// this shold double pts
				magnetSlider.gameObject.SetActive (true);

				magnetSlider.value=(float) t1/magMaxTime;
				magnetArea.SetActive (true);

				// do something with the powerup
				str1="Time to do something "+PowType;
			}
			else
			{PowType=99;
				// Restore back to normal
				magnetSlider.gameObject.SetActive (false);

				magnetArea.gameObject.SetActive (false);

				if (t2 > 0) 
				{
					jetSldrRectTransform.DOAnchorPosY(mgtPosYStore, animatingOrTweeningTime, false).SetEase(curv);
					
				
					fullSldrRectTransform.DOAnchorPosY(jetPosYStore, animatingOrTweeningTime, false).SetEase(curv);
				}
				else 
				{
					fullSldrRectTransform.DOAnchorPosY(mgtPosYStore, animatingOrTweeningTime, false).SetEase(curv);
				}
			}
		
		}

		if (t2 > 0)
		{
			temp = PowType;
			PowType = 2;
		} 
		else 
		{
			if (t1 < 0) {
				fullSldrRectTransform.DOAnchorPosY (mgtPosYStore, animatingOrTweeningTime, false).SetEase(curv);
			}
			else
			{
				fullSldrRectTransform.DOAnchorPosY(jetPosYStore, animatingOrTweeningTime, false).SetEase(curv);
			}
		}
		if (PowType == 2)
		{t2 -= Time.deltaTime;
			if (t2 > 0) 
			{
				cnt++;

				if (t1 > 0)
				{
					jetSldrRectTransform.DOAnchorPosY(jetPosYStore, animatingOrTweeningTime, false).SetEase(curv);
				}

				jetpackSlider.gameObject.SetActive (true);
				jetpackSlider.value = (float)t2 / jetMaxTime;

				if(Input.GetKey(KeyCode.Space)||Input.GetMouseButton (0))
				{
					thePC.myRigidbody.velocity = new Vector2 (thePC.myRigidbody.velocity.x, thrust);
				}

				if (cnt > 5) 
				{
					sgc.CoinWave (t2);
					cnt = 0;
				}
				// do something with the powerup
				str1="Time to do something "+PowType;
			}
			else
			{ // to get more memory iniatialise timer to 0 OR DO SOMETING ELSE ex set powType to 99;
				if (t1 > 0) 
				{
					fullSldrRectTransform.DOAnchorPosY(mgtPosYStore, animatingOrTweeningTime, false).SetEase(curv);
				}

				jetpackSlider.gameObject.SetActive (false);


				/*	26 Jan 2018		if (thePC.hasTeleported == false) {
					PlPos.transform.position = new Vector3 (PlPos.transform.position.x, 7.0f, PlPos.transform.position.z);
					CPos.transform.position = new Vector3 (PlPos.transform.position.x, 1.0f, PlPos.transform.position.z);
					PowType = 99;
				}
				     // 26 Jan 2018
				else 
				
				{
		////	26Jan		thePC.hasTeleported = false;
								

					// this is causing problem when player telepots and take another jet pack and then teleports
					// as t2 for each powerup is different so the earlier one will say hasTeleported FALSE (i.e. make falll)when his t2<0 
					// but on considering latter part it has TELEPORTED but, the earlier one has made HasTeleported false
				}
				// Restore back to normal


26 Jan 2018*/
			}

		}

		if (t3 > 0) 
		{
			temp = PowType;
			PowType = 3;
		}
		if (PowType == 3)
		{t3 -= Time.deltaTime;
			if (t3 > 0) 
			{
				if (t1 > 0 && t2 > 0) 
				{
					fullSldrRectTransform.DOAnchorPosY(fullPosYStore, animatingOrTweeningTime, false).SetEase(curv);
				}
				
				fullcoinSlider.gameObject.SetActive (true);

				fullcoinSlider.value = (float)t3 / fullMaxTime;
				thePgen.FullCoin = true;
				// do something with the powerup
				str1="Time to do something "+PowType;
			}
			else
			{ // to get more memory iniatialise timer to 0 OR DO SOMETING ELSE ex set powType to 99;

				PowType=99;

				fullcoinSlider.gameObject.SetActive (false);

				// Restore back to normal
			}

		}


	
	
	// powType=99 is for default play withut powerup
		if(PowType==99)                   //  this is not performance friendly as it will run unnecessarily
		{
			thePgen.FullCoin = false;
		}
	
	}


	public void ActivatePowerup(int ty,float time)
	{
		PowLen= time;


		PowType = ty;
		if (PowType == 1)
		{t1 = PowLen;
		}
		if (PowType == 2)
		{t2 = PowLen;
		}
		if (PowType == 3)
		{t3 = PowLen;
		}
/*		if (PowType ==3)
		{t3 = PowLen;
		}
		if (PowType == 4)
		{t4= PowLen;
		}
		if (PowType ==5)
		{t5 = PowLen;
		}
*/
	}
}
