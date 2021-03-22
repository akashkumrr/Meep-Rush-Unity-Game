using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class sineGenCoin : MonoBehaviour {

	public ObjectPooler coinPooler;
	public ObjectPooler TelePooler;
	public CoinGenerator CoinGen;
	public Transform plyT;
	public GameObject g;
	public GameObject TeleportPAD;

	public float spawnTeleportTime;

	public int rndNo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		plyT = g.transform;

		spawnTeleportTime += Time.deltaTime;


	}

	public void CoinWave(float tm)
	{//while (tm > 0)		{
		float y = 3.0f*Mathf.Sin (tm*2.0f);

	
		//	float x = Mathf.Asin (tm/10.0f);
			GameObject g = coinPooler.GetPooledObject ();
		g.transform.position =new Vector3(plyT.position.x+15.0f,200+y,plyT.position.z);
		//	g.transform.position =new Vector3(g.transform.position.x+x,g.transform.position.y,g.transform.position.z) ;
		g.GetComponent<magnetic> ().magnetZone = false;	
		g.SetActive (true);

		///if (Random.Range (0.0f, 10.0f) >= 5.0f&&plyT.transform.position.x>CoinGen.GetTeleportPosition().x) {

		if (spawnTeleportTime >= 2.5f) {
			GameObject TeleportPAD = TelePooler.GetPooledObject ();
			TeleportPAD.transform.position = new Vector3 (g.transform.position.x+ 4.0f, g.transform.position.y + 6.0f, g.transform.position.z);
			TeleportPAD.SetActive (true);



				GameObject TeleportPAD2 = TelePooler.GetPooledObject ();
				TeleportPAD2.transform.position = new Vector3 (g.transform.position.x, g.transform.position.y - 6.0f, g.transform.position.z);
				TeleportPAD2.SetActive (true);

				spawnTeleportTime = 0;

		}



	
	}
}
