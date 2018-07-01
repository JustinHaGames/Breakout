using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	// Use this for initialization
	void Start () {
		//declare that the gamemanager object is the instance
		instance = this; 

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

	}
}
