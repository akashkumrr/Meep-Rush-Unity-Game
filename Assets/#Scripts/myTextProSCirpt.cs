using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class myTextProSCirpt : MonoBehaviour {


	//private TextMeshProUGUI tMesh;

	// Use this for initialization
	void Start () {
		TextMeshProUGUI	tMesh=GetComponent<TextMeshProUGUI> ();
		tMesh.text = "This is a sample test text";
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
}
