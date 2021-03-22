using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class sliderTweenedSmooth : MonoBehaviour {

	public Slider mySld;
	public float fv;
	public float tm;

	[Space(10)]
	public AnimationCurve curve;

	// Use this for initialization
	void Start () {
	//	mySld.value = 1;
		mySld.DOValue(fv,tm,false).SetEase (curve);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
