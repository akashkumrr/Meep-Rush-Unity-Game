using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {



	public PlatformGenerator platGEN;
	//public magnetic theMag;
	public ObjectPooler coinPool;
	public float distanceBetweenCoins;


	//public Vector3 GPosition;

	public void SpawnCoins(Vector3 startPosition,int platSize)
	{int rand = Random.Range (1, 10);

		if (platSize == 3) 
		{
			
				GameObject coin1 = coinPool.GetPooledObject ();
				coin1.transform.position = new Vector3 (startPosition.x, startPosition.y, startPosition.z);
				coin1.SetActive (true);
				coin1.GetComponent<magnetic> ().magnetZone = false;


			if (rand > 8)
			{
				GameObject coin2 = coinPool.GetPooledObject ();
				coin2.transform.position = new Vector3 (startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z);
				coin2.SetActive (true);
				coin2.GetComponent<magnetic> ().magnetZone = false;
			}

			GameObject coin3 = coinPool.GetPooledObject ();
			coin3.transform.position = new Vector3 (startPosition.x - distanceBetweenCoins - 1, startPosition.y, startPosition.z);
			coin3.SetActive (true);
			coin3.GetComponent<magnetic> ().magnetZone = false;

			//GPosition = startPosition;
		}
		else if (platSize == 5) 
		{
			if (rand > 7) {
				GameObject coin1 = coinPool.GetPooledObject ();
				coin1.transform.position = new Vector3 (startPosition.x - 1, startPosition.y, startPosition.z);
				coin1.SetActive (true);
				coin1.GetComponent<magnetic> ().magnetZone = false;
			}
				GameObject coin2 = coinPool.GetPooledObject ();
				coin2.transform.position = new Vector3 (startPosition.x - 2, startPosition.y, startPosition.z);
				coin2.SetActive (true);
				coin2.GetComponent<magnetic> ().magnetZone = false;
			


				GameObject coin3 = coinPool.GetPooledObject ();
				coin3.transform.position = new Vector3 (startPosition.x - 3, startPosition.y, startPosition.z);
				coin3.SetActive (true);
				coin3.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin4 = coinPool.GetPooledObject ();
			coin4.transform.position = new Vector3 (startPosition.x-4, startPosition.y, startPosition.z);
			coin4.SetActive (true);
			coin4.GetComponent<magnetic> ().magnetZone = false;

			if (rand > 9) {
				
				GameObject coin5 = coinPool.GetPooledObject ();
				coin5.transform.position = new Vector3 (startPosition.x - 5, startPosition.y, startPosition.z);
				coin5.SetActive (true);
				coin5.GetComponent<magnetic> ().magnetZone = false;
			}
		}
		else if (platSize == 7) 
		{
		
			if (rand > 5)
			{
				GameObject coin1 = coinPool.GetPooledObject ();
				coin1.transform.position = new Vector3 (startPosition.x - 1, startPosition.y, startPosition.z);
				coin1.SetActive (true);
				coin1.GetComponent<magnetic> ().magnetZone = false;

				GameObject coin2 = coinPool.GetPooledObject ();
				coin2.transform.position = new Vector3 (startPosition.x - 2, startPosition.y, startPosition.z);
				coin2.SetActive (true);
				coin2.GetComponent<magnetic> ().magnetZone = false;
			}

			GameObject coin3 = coinPool.GetPooledObject ();
			coin3.transform.position = new Vector3 (startPosition.x-3, startPosition.y, startPosition.z);
			coin3.SetActive (true);
			coin3.GetComponent<magnetic> ().magnetZone = false;


				GameObject coin4 = coinPool.GetPooledObject ();
				coin4.transform.position = new Vector3 (startPosition.x - 4, startPosition.y, startPosition.z);
				coin4.SetActive (true);
				coin4.GetComponent<magnetic> ().magnetZone = false;

				GameObject coin5 = coinPool.GetPooledObject ();
				coin5.transform.position = new Vector3 (startPosition.x - 5, startPosition.y, startPosition.z);
				coin5.SetActive (true);
				coin5.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin6 = coinPool.GetPooledObject ();
			coin6.transform.position = new Vector3 (startPosition.x-6, startPosition.y, startPosition.z);
			coin6.SetActive (true);
			coin6.GetComponent<magnetic> ().magnetZone = false;

			if (rand > 8) {
				
				GameObject coin7 = coinPool.GetPooledObject ();
				coin7.transform.position = new Vector3 (startPosition.x - 7, startPosition.y, startPosition.z);
				coin7.SetActive (true);
				coin7.GetComponent<magnetic> ().magnetZone = false;
			}



		} 
		else
		{
			if (rand > 8) 
			{
				GameObject coin1 = coinPool.GetPooledObject ();
				coin1.transform.position = new Vector3 (startPosition.x - 1, startPosition.y, startPosition.z);
				coin1.SetActive (true);
				coin1.GetComponent<magnetic> ().magnetZone = false;

				GameObject coin2 = coinPool.GetPooledObject ();
				coin2.transform.position = new Vector3 (startPosition.x - 2, startPosition.y, startPosition.z);
				coin2.SetActive (true);
				coin2.GetComponent<magnetic> ().magnetZone = false;

				GameObject coin3 = coinPool.GetPooledObject ();
				coin3.transform.position = new Vector3 (startPosition.x - 3, startPosition.y, startPosition.z);
				coin3.SetActive (true);
				coin3.GetComponent<magnetic> ().magnetZone = false;
			}

			GameObject coin4 = coinPool.GetPooledObject ();
			coin4.transform.position = new Vector3 (startPosition.x-4, startPosition.y, startPosition.z);
			coin4.SetActive (true);
			coin4.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin5 = coinPool.GetPooledObject ();
			coin5.transform.position = new Vector3 (startPosition.x-5, startPosition.y, startPosition.z);
			coin5.SetActive (true);
			coin5.GetComponent<magnetic> ().magnetZone = false;

			GameObject coin6 = coinPool.GetPooledObject ();
			coin6.transform.position = new Vector3 (startPosition.x-6, startPosition.y, startPosition.z);
			coin6.SetActive (true);
			coin6.GetComponent<magnetic> ().magnetZone = false;


			if (rand >= 9) {
				
				GameObject coin7 = coinPool.GetPooledObject ();
				coin7.transform.position = new Vector3 (startPosition.x - 7, startPosition.y, startPosition.z);
				coin7.SetActive (true);
				coin7.GetComponent<magnetic> ().magnetZone = false;
			
				GameObject coin8 = coinPool.GetPooledObject ();
				coin8.transform.position = new Vector3 (startPosition.x - 8, startPosition.y, startPosition.z);
				coin8.SetActive (true);
				coin8.GetComponent<magnetic> ().magnetZone = false;

				GameObject coin9 = coinPool.GetPooledObject ();
				coin9.transform.position = new Vector3 (startPosition.x - 9, startPosition.y, startPosition.z);
				coin9.SetActive (true);
				coin9.GetComponent<magnetic> ().magnetZone = false;
			}



		}
	
		

	
	}

	public Vector3 GetTeleportPosition()
	{
		//return GPosition;

		return platGEN.CalTelepos;

	}


	void Update()
	{

	}





}
