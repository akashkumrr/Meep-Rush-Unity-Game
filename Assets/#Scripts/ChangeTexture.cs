using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTexture : MonoBehaviour {

	public Text myWorldText;


	public Texture[] myTexture;
	//public float timer = 5.0f ;
	public int i=0;
	public PlayerController theMyPlayerController;
	public float j;
	public GameObject textGameObject;
	public float textTimer ;


	// Use this for initialization
	void Start () {
		textGameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		

		textTimer -=Time.deltaTime;
		if (textTimer <= 0)
		{
			textGameObject.SetActive (false);
		}
		j=theMyPlayerController.myVariable;
		if (j==0) 
		{   
			textTimer=2.0f;

			textGameObject.SetActive(true);
			myWorldText.text = " WORLD " + (i+1);

			i++;
			if (i < myTexture.Length)
				GetComponent<Renderer> ().material.mainTexture = myTexture [i];
			else
				i = 0; 

		}
	}
}
