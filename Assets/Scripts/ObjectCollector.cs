using UnityEngine;
using System.Collections;

public class ObjectCollector : MonoBehaviour
{
		void OnTriggerEnter2D (Collider2D obj)
		{
				if (obj.gameObject.transform.parent) {
						obj.gameObject.transform .parent.gameObject .SetActive (false);
				} else {
						obj.gameObject.SetActive (false);
				}
		}
}
