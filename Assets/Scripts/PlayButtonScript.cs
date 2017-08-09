using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
		void OnMouseDown ()
		{
            SceneManager.LoadScene("GameScene");
		}	
}
