using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class myTweeningScript : MonoBehaviour {

	public Vector2 XAndYSize;
	[Space(10)]
	public float timeToBeTaken;
	[Space(10)]
	public RectTransform rctTransfrom;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		rctTransfrom.DOSizeDelta (XAndYSize, timeToBeTaken, false).SetLoops(3);

	}
}
