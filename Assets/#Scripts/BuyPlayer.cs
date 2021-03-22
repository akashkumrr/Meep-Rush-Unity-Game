using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPlayer : MonoBehaviour {


	public BuyingScreens objToBeActivated;
	//public BuyObj updateObj;



	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void BackClick()
	{
		if (objToBeActivated.t > 0) 
		{objToBeActivated.t=objToBeActivated.t-1;
			objToBeActivated.myBuyingScreen [objToBeActivated.t].SetActive (true);

			objToBeActivated.t=objToBeActivated.t+1;
			objToBeActivated.myBuyingScreen [objToBeActivated.t].SetActive (false);

			objToBeActivated.t=objToBeActivated.t-1;

		}
	}

	public void NextClick()
	{
		if (objToBeActivated.t <4) 
		{objToBeActivated.t=objToBeActivated.t+1;
			objToBeActivated.myBuyingScreen [objToBeActivated.t].SetActive (true);

			objToBeActivated.t=objToBeActivated.t-1;
			objToBeActivated.myBuyingScreen [objToBeActivated.t].SetActive (false);

			objToBeActivated.t=objToBeActivated.t+1;

		}

	}


	public void MainBuy()
	{objToBeActivated.t = 0;
		objToBeActivated.myBuyingScreen [objToBeActivated.t].SetActive (true);
	}

	public void CloseBuy()
	{
		objToBeActivated.myBuyingScreen [objToBeActivated.t].SetActive (false);
	}





}
