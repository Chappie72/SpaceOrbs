using UnityEngine;
using System.Collections;

public class AsteroidScroller : MonoBehaviour
{
		public float minHeight;
		public float maxHeight;
		public float scrollSpeed;

		void OnEnable ()
		{
				transform.position = new Vector2 (transform.position.x, Random.Range (minHeight, maxHeight));
		}

		// Update is called once per frame
		void Update ()
		{
				GetComponent<Rigidbody2D>().velocity = new Vector2 (scrollSpeed * -1, GetComponent<Rigidbody2D>().velocity.y);
		}
}
