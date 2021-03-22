using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class displayHighscores : MonoBehaviour {


	public TextMeshProUGUI highGrav;
	public TextMeshProUGUI highRope;
	public TextMeshProUGUI highNight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		highGrav.text = ((int)PlayerPrefs.GetFloat ("HSGrav")).ToString();
		highRope.text =((int)PlayerPrefs.GetFloat ("HSRope")).ToString();
		highNight.text = ((int)PlayerPrefs.GetFloat ("HSNight")).ToString();
	}
}
