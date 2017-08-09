using UnityEngine;
using System.Collections;

public class OrbController : MonoBehaviour
{
		public float rotateDirection = 1f;
		public float rotateSpeed = 5f;
		public bool isRotating = false;

		public GameObject explosion;

		private GameManager gameManager;
		
		void Start ()
		{
				GameObject gameManagerObject = GameObject.FindWithTag ("GameController");
				if (gameManagerObject != null) {
						gameManager = gameManagerObject.GetComponent<GameManager> ();
				}
		}

		void Update ()
		{
				if (!gameManager.isGameOver) {
						UpdateUserInput ();
						if (isRotating) {
								transform.Rotate (Vector3.forward * (rotateDirection * rotateSpeed) * -1);
						}
				}
		}
	
		void UpdateUserInput ()
		{
				if (Application .platform == RuntimePlatform.WindowsEditor) {
						var inputAxis = Input.GetAxis ("Horizontal");
						if (inputAxis != 0) {
								isRotating = true;
								rotateDirection = inputAxis;
						} else {
								isRotating = false;
						}
				} else if (Input.touchCount > 0) {
						var touch = Input.GetTouch (0);
						if (touch.phase == TouchPhase.Began) {
								isRotating = true;
								if (touch.position.x < Screen.width / 2) {
										rotateDirection = -1f;
								} else {
										rotateDirection = 1f;
								}
						}
				} else {
						isRotating = false;
				}
		}
	
		void OnTriggerEnter2D (Collider2D obj)
		{
				gameManager.AddScore (1);
		}

		void OnCollisionEnter2D (Collision2D obj)
		{
				//if (explosion != null) {
				//		Instantiate (explosion, obj.transform.position, obj.transform.rotation);
				//}

				//obj.gameObject.SetActive (false);
				//gameObject.SetActive (false);

				//gameManager.GameOver ();
		}
}
