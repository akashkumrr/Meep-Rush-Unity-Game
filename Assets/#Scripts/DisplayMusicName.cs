using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMusicName : MonoBehaviour {

	public AudioSource theRefer;
	public Text musicName;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		musicName.text = "NOW PLAYING : " + theRefer.clip.name;
	}
}
