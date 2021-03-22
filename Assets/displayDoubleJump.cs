using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class displayDoubleJump : MonoBehaviour {


	public PlayerController thePC;
	public TextMeshProUGUI t;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		t.text= thePC.canDoubleJump.ToString();
		
	}
}
