using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolSpawner : MonoBehaviour
{
		public int pooledAmount;
		public bool willGrow = true;
		public float spawnFrequency;
		public GameObject pooledObject;
	
		List<GameObject> pooledObjects;
	
		void Start ()
		{
				pooledObjects = new List<GameObject> ();
				for (int i = 0; i < pooledAmount; i++) {
						GameObject obj = (GameObject)Instantiate (pooledObject);
						obj.SetActive (false);
						pooledObjects.Add (obj);
				}

				InvokeRepeating ("SpawnGameObject", 2f, spawnFrequency);
		}
	
		public GameObject GetPooledObject ()
		{
				for (int i = 0; i < pooledObjects.Count; i++) {
						if (!pooledObjects [i].activeInHierarchy) {
								return pooledObjects [i];
						}
				}
		
				if (willGrow) {
						GameObject obj = (GameObject)Instantiate (pooledObject);
						pooledObjects.Add (obj);
						return obj;
				}
				return null;
		}

		void SpawnGameObject ()
		{
				GameObject obj = GetPooledObject ();
				if (obj == null) {
						return;
				}
		
				obj.transform.position = transform.position;
				obj.SetActive (true);
		}
}
