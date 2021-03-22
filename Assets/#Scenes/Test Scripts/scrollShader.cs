using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrollShader : MonoBehaviour {

	public Transform LoadingBar;
	public float curAmt;
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (curAmt < 100) {
			curAmt += speed * Time.deltaTime;
		}
		LoadingBar.GetComponent<Image> ().fillAmount = curAmt / 100;
	}
}
