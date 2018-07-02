using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour {

	//The Gamemanager will act as a singleton so different gameobject can interact with eachother in different instances
	public static GameManager instance; 

	public bool gameStart; 

	public bool launched; 
	public bool playerRight; 
	public bool playerLeft; 

	public GameObject bricks; 

	public float blockPosX;
	public float blockPosY; 

	public int score; 

	public Text scoreText; 
	public Text gameOverText;
	public Text restartText; 

	public bool gameOver; 

	public bool brickHit; 
	public AudioClip hitSound; 
	public AudioSource audioManager; 

	// Use this for initialization
	void Start () {

		//declare that the gamemanager object is the instance
		instance = this; 

		//Get access to the audio source component at the start
		audioManager = GetComponent<AudioSource> ();

		//the game doesn't start until the ball is launched
		gameStart = false; 

		//This forloop spawns every brick while also moving the next brick's position
		//After the 12th brick of each row, the next brick will start at the original x position and move down
		for (int i = 0; i < 48; i++) {
			if (i % 12 == 0 && i != 0) {
				blockPosX = -7f;
				blockPosY -= 1.25f;
			}
			Instantiate (bricks, new Vector3(blockPosX,blockPosY,transform.position.z), Quaternion.identity);
			blockPosX += 1.25f;
		}

	}
	
	// Update is called once per frame
	void Update () {

		//Show the score at all times
		scoreText.text = "Score: " + score; 

		//Make a sound effect every time a brick is hit
		if (brickHit) {
			audioManager.PlayOneShot (hitSound,1f);
			brickHit = false;
		}

		//If there are no bricks on the screen, set win text
		if (GameObject.FindGameObjectWithTag ("Brick") == null) {
			Time.timeScale = 0; 
			gameOverText.text = "You Win!";
			restartText.text = "Press R to restart!";
			if (Input.GetKeyDown (KeyCode.R)) {
				Time.timeScale = 1f; 
				SceneManager.LoadScene (0);
			}
		}

		//Game Over happens when the ball's Y position is at the bottom of the scene. 
		//Stop the time and show that it is Game Over
		if (gameOver) {
			Time.timeScale = 0; 
			gameOverText.text = "Game Over";
			restartText.text = "Press R to restart!";
			if (Input.GetKeyDown (KeyCode.R)) {
				Time.timeScale = 1f; 
				SceneManager.LoadScene (0);
			}
		}

	}

}
