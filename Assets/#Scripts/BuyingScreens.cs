using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingScreens : MonoBehaviour {


	public GameObject[] myBuyingScreen;
	public int t=0;

	// Use this for initialization
	void Start () {
		for (t = 0; t < myBuyingScreen.Length; ++t) 
		{
			myBuyingScreen [t].SetActive (false);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
