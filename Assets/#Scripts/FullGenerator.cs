using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullGenerator : MonoBehaviour {

	public ObjectPooler cPool;


	//

	void Start () {
		/*platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;*/
		/*
		platformWidths = new float[theObjectPools.Length];

		for (int i = 0; i < theObjectPools.Length; i++)
		{
			platformWidths[i]= theObjectPools[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
		}
	}*/
}
	//



public void SpawnAllCoins(Vector3 stPos,int how)
	{
		/* GameObject[] coin;
	int cnt = how;
	coin= new GameObject[cnt+1];

	for (int i = 0; i <cnt; i++)
		{
			coin[i]= cPool.GetPooledObject ();
		}
		Debug.Log ("hey");
	while (cnt>0) 
		{
			coin[how] = cPool.GetPooledObject ();
		coin[cnt].transform.position =new Vector3(stPos.x-how,stPos.y,stPos.z);
		coin[cnt].SetActive (true);
		coin[cnt].GetComponent<magnetic> ().magnetZone = false;
			cnt--;

		}
	}*/

		if (how == 3) {
			GameObject coin1 = cPool.GetPooledObject ();
			coin1.transform.position = new Vector3 (stPos.x-1, stPos.y, stPos.z);
			coin1.SetActive (true);
			coin1.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin2 = cPool.GetPooledObject ();
			coin2.transform.position = new Vector3 (stPos.x-2, stPos.y, stPos.z);
			coin2.SetActive (true);
			coin2.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin3 = cPool.GetPooledObject ();
			coin3.transform.position = new Vector3 (stPos.x-3, stPos.y, stPos.z);
			coin3.SetActive (true);
			coin3.GetComponent<magnetic> ().magnetZone = false;


		} else if (how == 5) {
			GameObject coin1 = cPool.GetPooledObject ();
			coin1.transform.position = new Vector3 (stPos.x-1, stPos.y, stPos.z);
			coin1.SetActive (true);
			coin1.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin2 = cPool.GetPooledObject ();
			coin2.transform.position = new Vector3 (stPos.x-2, stPos.y, stPos.z);
			coin2.SetActive (true);
			coin2.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin3 = cPool.GetPooledObject ();
			coin3.transform.position = new Vector3 (stPos.x-3, stPos.y, stPos.z);
			coin3.SetActive (true);
			coin3.GetComponent<magnetic> ().magnetZone = false;
			GameObject coin4 = cPool.GetPooledObject ();
			coin4.transform.position = new Vector3 (stPos.x-4, stPos.y, stPos.z);
			coin4.SetActive (true);
			coin4.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin5 = cPool.GetPooledObject ();
			coin5.transform.position = new Vector3 (stPos.x-5, stPos.y, stPos.z);
			coin5.SetActive (true);
			coin5.GetComponent<magnetic> ().magnetZone = false;

		} else if (how == 7) {
			GameObject coin1 = cPool.GetPooledObject ();
			coin1.transform.position = new Vector3 (stPos.x-1, stPos.y, stPos.z);
			coin1.SetActive (true);
			coin1.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin2 = cPool.GetPooledObject ();
			coin2.transform.position = new Vector3 (stPos.x-2, stPos.y, stPos.z);
			coin2.SetActive (true);
			coin2.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin3 = cPool.GetPooledObject ();
			coin3.transform.position = new Vector3 (stPos.x-3, stPos.y, stPos.z);
			coin3.SetActive (true);
			coin3.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin4 = cPool.GetPooledObject ();
			coin4.transform.position = new Vector3 (stPos.x-4, stPos.y, stPos.z);
			coin4.SetActive (true);
			coin4.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin5 = cPool.GetPooledObject ();
			coin5.transform.position = new Vector3 (stPos.x-5, stPos.y, stPos.z);
			coin5.SetActive (true);
			coin5.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin6 = cPool.GetPooledObject ();
			coin6.transform.position = new Vector3 (stPos.x-6, stPos.y, stPos.z);
			coin6.SetActive (true);
			coin6.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin7 = cPool.GetPooledObject ();
			coin7.transform.position = new Vector3 (stPos.x-7, stPos.y, stPos.z);
			coin7.SetActive (true);
			coin7.GetComponent<magnetic> ().magnetZone = false;



		} else if (how == 9) {
			GameObject coin1 = cPool.GetPooledObject ();
			coin1.transform.position = new Vector3 (stPos.x-1, stPos.y, stPos.z);
			coin1.SetActive (true);
			coin1.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin2 = cPool.GetPooledObject ();
			coin2.transform.position = new Vector3 (stPos.x-2, stPos.y, stPos.z);
			coin2.SetActive (true);
			coin2.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin3 = cPool.GetPooledObject ();
			coin3.transform.position = new Vector3 (stPos.x-3, stPos.y, stPos.z);
			coin3.SetActive (true);
			coin3.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin4 = cPool.GetPooledObject ();
			coin4.transform.position = new Vector3 (stPos.x-4, stPos.y, stPos.z);
			coin4.SetActive (true);
			coin4.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin5 = cPool.GetPooledObject ();
			coin5.transform.position = new Vector3 (stPos.x-5, stPos.y, stPos.z);
			coin5.SetActive (true);
			coin5.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin6 = cPool.GetPooledObject ();
			coin6.transform.position = new Vector3 (stPos.x-6, stPos.y, stPos.z);
			coin6.SetActive (true);
			coin6.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin7 = cPool.GetPooledObject ();
			coin7.transform.position = new Vector3 (stPos.x-7, stPos.y, stPos.z);
			coin7.SetActive (true);
			coin7.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin8 = cPool.GetPooledObject ();
			coin8.transform.position = new Vector3 (stPos.x-8, stPos.y, stPos.z);
			coin8.SetActive (true);
			coin8.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin9 = cPool.GetPooledObject ();
			coin9.transform.position = new Vector3 (stPos.x-9, stPos.y, stPos.z);
			coin9.SetActive (true);
			coin9.GetComponent<magnetic> ().magnetZone = false;



		} 

	}
}