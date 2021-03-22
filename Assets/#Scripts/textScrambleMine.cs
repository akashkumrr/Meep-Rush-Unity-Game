using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class textScrambleMine : MonoBehaviour {


	public AnimationCurve curve;
	public Text maText;
	[Space(10)]
	public float time;
	[Space(10)]
	public string endString;




	// Use this for initialization
	void Start () {
		maText.DOText (endString, time, true, ScrambleMode.None,"").SetEase(curve);
	


	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
