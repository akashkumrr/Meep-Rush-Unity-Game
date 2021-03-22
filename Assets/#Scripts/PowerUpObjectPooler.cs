using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpObjectPooler : MonoBehaviour {
	public GameObject pooledObject;

	public int pooledAmount;

	public List<GameObject> pooledObjects;

	// Use this for initialization
	void Start () {
		pooledObjects = new List<GameObject> ();

		for (int i = 0; i < pooledAmount; i++)
		{
			GameObject obj = (GameObject)Instantiate (pooledObject);
			//obj.SetActive (false);
			obj.GetComponent<SpriteRenderer>().sprite=null;
			pooledObjects.Add (obj);

		}

	}

	public GameObject GetPooledPowerObject()
	{
		for (int i = 0; i < pooledObjects.Count; i++) 
		{
			if (pooledObjects [i].GetComponent<SpriteRenderer>().sprite==null) 
			{
				return pooledObjects[i];
			}

		}

		GameObject obj = (GameObject)Instantiate (pooledObject);
		obj.GetComponent<SpriteRenderer>().sprite=null;
		pooledObjects.Add (obj);

		return obj;


	}
}
