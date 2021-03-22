using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupGenerator : MonoBehaviour {

	public PowerUpObjectPooler[] powerupPools;
	public float distanceBetweenPower;



	//  in this script you have to assign the sprite according to the type of the powerup so
	public Sprite s1;
	public Sprite s2;

	public TopPowerUpManager Pman;

	public void SpawnPowerup(Vector3 startPosition)
	{
		if (Pman.PowType == 1) 
		{
		GameObject powerup1 = powerupPools[0].GetPooledPowerObject ();
		powerup1.transform.position = new Vector3(startPosition.x,startPosition.y,startPosition.z);
		//coin1.SetActive (true);
		powerup1.GetComponent<SpriteRenderer> ().sprite = s1;
		}

		if (Pman.PowType == 2) 
		{
		GameObject powerup2 = powerupPools[1].GetPooledPowerObject ();
		powerup2.transform.position =new Vector3(startPosition.x-distanceBetweenPower,startPosition.y,startPosition.z);
		powerup2.GetComponent<SpriteRenderer> ().sprite = s2;
		}
	}
}
