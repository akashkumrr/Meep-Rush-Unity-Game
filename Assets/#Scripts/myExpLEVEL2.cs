using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myExpLEVEL2 : MonoBehaviour {

	public int num,a,b,c,d,i,j;

	// Use this for initialization
	void Start () {
		
		}
	
	// Update is called once per frame
	void Update () {

		do {
			a = num % 10;
			j = num / 10;
			num = num / 10;
		} while(j == 0);


	}
}
