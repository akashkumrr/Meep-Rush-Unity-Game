using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupTorch : MonoBehaviour {

	public GameObject torch;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player" && other.gameObject.tag == "Player")
		{
	//		torch.SetActive (true);
	//		StopCoroutine (onTime ());
	//		StartCoroutine (onTime ());

			gameObject.GetComponent<SpriteRenderer>().sprite=null;
		}



	}

/*	IEnumerator onTime()
	{
		print ("inside corourtine");

		float tm = 0.0f;

		while (tm <= 5.0f) 
		{
			tm += Time.deltaTime;

			yield return null;
		}

		print (tm);

		print ("Deactivated");
		torch.SetActive (false);
		yield return null;
	}

*/
}
