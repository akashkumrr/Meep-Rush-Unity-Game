using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportation : MonoBehaviour {

	public GameObject PLAYER;
	public GameObject CAM;
	public CoinGenerator Cgen;

	public GameObject prefabParticleSystem;
	public GameObject prefabParticleSystem2;


	void OnCollisionEnter2D (Collision2D other)   //      check whether small d or capital D
	{

		if (other.gameObject.tag == "Player") 
		{ 
				PLAYER.transform.position = new Vector3 (Cgen.GetTeleportPosition ().x - 5.0f, Cgen.GetTeleportPosition ().y + 2.0f, Cgen.GetTeleportPosition ().z);
				CAM.transform.position= new Vector3 (CAM.transform.position.x, Cgen.GetTeleportPosition ().y + 2.0f,CAM.transform.position.z);
		}

		Instantiate (prefabParticleSystem2, PLAYER.transform.position, Quaternion.identity);
	
		Time.timeScale = 0.1f;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
	
		PLAYER.GetComponent<PlayerController> ().etc22 ();
	}


	public void SendPlayerBackUsingAd()
	{
		

		PLAYER.transform.position = new Vector3 (Cgen.GetTeleportPosition ().x - 5.0f, Cgen.GetTeleportPosition ().y + 2.0f, Cgen.GetTeleportPosition ().z);
		CAM.transform.position= new Vector3 (CAM.transform.position.x, Cgen.GetTeleportPosition ().y + 2.0f,CAM.transform.position.z);
	
	
		Instantiate (prefabParticleSystem, PLAYER.transform.position, Quaternion.identity);

		Time.timeScale = 0.2f;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;


		PLAYER.GetComponent<PlayerController> ().etc ();
	}



}
