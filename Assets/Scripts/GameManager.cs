using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	
		public int gameScore;
		public int lastScore;
		public int highScore;
	
		public GUIText gameScoreText;
	
		public float gameSpeed = 3f;
		public float spawnFrequency = 4f;

		public bool isGameOver = false;
	
		void Start ()
		{
				Load ();
				UpdateScore ();
		}
	
		public float GetGameSpeed ()
		{
				return gameSpeed;
		}
	
		public void AddScore (int score)
		{
				gameScore += score;
				UpdateScore ();
				//IncreaseGameDifficulty ();
		}
	
//	void IncreaseGameDifficulty()
//	{
//		gameSpeed = UnityEngine.Random.Range (gameSpeed, gameSpeed + 0.2f);
//		
//		if (currentScore > 11 && currentScore < 25 && spawnFrequency != 3f) 
//		{
//			spawnFrequency = 3f;
//			SpawnScript.instance.UpdateSpawnFrequency(spawnFrequency, this);
//		} 
//		else if (currentScore > 25 && currentScore < 51 && spawnFrequency != 2f) 
//		{
//			spawnFrequency = 2f;
//			SpawnScript.instance.UpdateSpawnFrequency(spawnFrequency, this);
//		}
//		else if (currentScore > 51 && spawnFrequency != 1.5f)
//		{
//			spawnFrequency = 1.5f;
//			SpawnScript.instance.UpdateSpawnFrequency(spawnFrequency, this);
//		}
//	}
	
		void UpdateScore ()
		{
				if (gameScoreText != null)
						gameScoreText.text = "" + gameScore;
		}

		public void GameOver ()
		{
				if (!isGameOver) {
					    isGameOver = true;
						Save ();
						StartCoroutine ("DelayMenuScene");
				}
		}

		IEnumerator  DelayMenuScene ()
		{
			yield return new WaitForSeconds (2f);
            SceneManager.LoadScene("MenuScene");
		}
	
		void Save ()
		{
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream fs = File.Create (Application.persistentDataPath + "/orbitalInfo.dat");
		
				OrbitalData data = new OrbitalData ();
		
				if (gameScore > highScore) {
						highScore = gameScore;
				}
		
				data.highScore = highScore;
				data.lastScore = gameScore;
		
				bf.Serialize (fs, data);
				fs.Close ();
		}
	
		void Load ()
		{
				if (File.Exists (Application .persistentDataPath + "/orbitalInfo.dat")) {
						BinaryFormatter bf = new BinaryFormatter ();
						FileStream fs = File.Open (Application .persistentDataPath + "/orbitalInfo.dat", FileMode.Open);
						OrbitalData data = (OrbitalData)bf.Deserialize (fs);
						fs.Close ();
			
						gameScore = 0;
						lastScore = data.lastScore;
						highScore = data.highScore;
			
				}
		}
}

[Serializable]
class OrbitalData
{
		public int highScore;
		public int lastScore;
}
