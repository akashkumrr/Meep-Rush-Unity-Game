using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ONmissionCOMPLETE : MonoBehaviour {

	public TextMeshProUGUI ranText;
	public TextMeshProUGUI coinText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		ranText.text =((int)PlayerPrefs.GetFloat ("orun")).ToString ();
		coinText.text=  PlayerPrefs.GetInt ("ocoin").ToString ();

	}


}
