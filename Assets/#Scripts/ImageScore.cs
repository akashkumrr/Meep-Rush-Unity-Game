using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageScore : MonoBehaviour {

	/*public Sprite[] mySprite;
	public int enter_num = 4254;
	public int[] remainder;
	public int division;
	public int myStoring;
*/
	public Sprite egSprite;
	public GameObject g;
	//public Sprite egSprite2;
	// Use this for initialization
	void Start () {
		Vector2 temp=transform.position;
		temp.x = transform.position.x;
		transform.position=temp*2;//offset;
		GetComponent<SpriteRenderer> ().sprite = egSprite;
	}
	
	// Update is called once per frame
	void Update () {

		//myFunction ();
		//Vector2 offset = new Vector2 (0.0f,transform.position.x);

		//Vector2 offset = new Vector2 (0.0f,transform.position.x);
		//GetComponent<SpriteRenderer> ().sprite = egSprite2;
		
	}

	/*public void myFunction()
	{
		do
		{		myStoring=enter_num%10;
			remainder[myStoring]=enter_num%10;
			division=enter_num/10;
			//cout<<remainder<<"\n";

		}
		while(division==0);

		for (int j = 0; j <= 9; ++j)
		{ if (remainder [j] ==j) 
			{
				GetComponent<SpriteRenderer> ().sprite = mySprite [j];
				Vector2 offset = new Vector2 (0.0f,transform.position.x);
			}//mySprite [j];
		}
	}*/

}
