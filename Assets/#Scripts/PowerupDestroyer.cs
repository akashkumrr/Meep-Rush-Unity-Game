using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupDestroyer : MonoBehaviour {

	// this script should work like the platform destroyer script as i.e. it has to iniatialise the unused powerup to sprite=null as deactivating them is not working for ourselves

	public GameObject platformDestructionPoint;

	// Use this for initialization
	void Start () {
		platformDestructionPoint = GameObject.Find ("PlatformDestructionPoint");
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x < platformDestructionPoint.transform.position.x)
		{
			//Destroy (gameObject);

			//gameObject.SetActive (false);

			gameObject.GetComponent<SpriteRenderer> ().sprite = null;
		}

	}
}
