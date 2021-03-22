using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class adPromptWatchScreen : MonoBehaviour {


	[Tooltip("t1 equals tmax")]
	public float t1;
	public float tMax;
	public GameManager gMan;
	public PlayerController thePC;
	public ScoreManager theSMan;
	public GameObject player;
	public TextMeshProUGUI coinProText;

	public Slider s;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		t1 -= Time.deltaTime;

		player.SetActive (false);

		theSMan.scoreIncreasing = false;

		s.value = t1/tMax;

		if (t1 < 0) 
		{
			coinProText.text = "0";
			gMan.whetherAdWatched = false;
			gMan.RestartGame ();
			t1 = 5;
			this.gameObject.SetActive (false);
		}
	}
}
