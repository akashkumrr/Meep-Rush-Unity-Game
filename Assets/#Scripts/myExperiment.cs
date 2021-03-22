using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myExperiment : MonoBehaviour {

	public Sprite[] sp;
	public Sprite noSp;
	/*public float returnHeight;
	public float returnWidth;
	public float returnXcood;
	public Vector2 itReturnSize;
	public float e;
	public float f;
	public float g;
	public float h;
	public float j;
	public float k;*/
	public Vector2 tempPos;
	public int a,  c, num;
	public int i,j;
	public ScoreManager imgSr;
	public GameManager gMan;



	// Use this for initialization
	void Start () {
		

		///////sp1.rect.xMin=f;

		/*returnHeight=sp1.rect.height;
		returnWidth = sp1.rect.width;
		itReturnSize = sp1.rect.size;
		returnXcood = sp1.rect.x;
		e = sp1.rect.xMax;

*/  //b = num / n* c;



	}
	
	// Update is called once per frame
	void Update () {
		
		everytime ();
	}

	public void everytime(){
		num = (int)imgSr.scoreCount;
		a = num/c % 10;

		for (i = 0; i < 10; ++i) 
		{
			if (a == i&&c<num) {
				GetComponent<SpriteRenderer> ().sprite =sp[i];
			}
		}
		GetComponent<SpriteRenderer> ().enabled = true;
		if (gMan.isClicked != 0) 
		{
			GetComponent<SpriteRenderer> ().sprite = noSp;
		}


		tempPos = transform.localPosition;
		tempPos.x = 0.5f;
		//tempPos.y = 3;
		transform.localPosition= tempPos;
	}
}
