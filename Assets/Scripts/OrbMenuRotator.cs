using UnityEngine;
using System.Collections;

public class OrbMenuRotator : MonoBehaviour
{

		public float direction;
		public float speed;
		
		float maxSpeed = 5f;
		float minSpeed = 1f;
		bool isAccelerating = true;

		// Update is called once per frame
		void Update ()
		{
				if (speed < maxSpeed && isAccelerating) {
						speed += Time.deltaTime;
				} else {
						isAccelerating = false;
						speed -= Time .deltaTime;
						if (speed < minSpeed) {
								isAccelerating = true;
						}
				}

				transform.Rotate (Vector3.forward * (direction * speed) * -1);
		}
}
