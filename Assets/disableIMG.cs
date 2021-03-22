using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class disableIMG : MonoBehaviour {
	public Image blkIMG;
	public float tm=1;
	// Use this for initialization
	void Start () {

		blkIMG.enabled = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		tm -= Time.deltaTime;
		if (tm < 0) {
			blkIMG.enabled = false;
		}
	}
}
