using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myCoinScript : MonoBehaviour {


	public Sprite[] sp;
	public Sprite noSp;
	public Vector2 tempPos;
	public int a,  c, num;
	public int i;

	//public ScoreManager imgSr;
	//public GameManager gMan;


	public PlayerController theMainCode;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		everytime ();
	}

	public void everytime(){
		num = theMainCode.coinCounter;
		a = num/c % 10;

		for (i = 0; i < 10; ++i) 
		{
			if (a == i&&c<num) {
				GetComponent<SpriteRenderer> ().sprite =sp[i];
			}
		}
		GetComponent<SpriteRenderer> ().enabled = true;
	
/*
		if (gMan.isClicked != 0) 
		{
			GetComponent<SpriteRenderer> ().sprite = noSp;
		}
		*/

		tempPos = transform.localPosition;
		tempPos.x = 0.5f;
		//tempPos.y = 3;
		transform.localPosition= tempPos;
	}




}
