using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {

	public GameObject creditMenu;
	public float timer=30;
	private int cnt = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (cnt == 1)
		{
			timer -= Time.deltaTime;
			if (timer < 0) 
			{creditMenu.SetActive (false);
			}
		}
	}

	public void CreditScreenOn()
	{cnt = 1;
		creditMenu.SetActive (true);
	}

	public void CreditScreenOff()
	{
		creditMenu.SetActive (false);
	}
}
