using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//The Gamemanager will act as a singleton so different gameobject can interact with eachother in different instances
	public static GameManager instance; 

	public bool gameStart; 

	public bool launched; 
	public bool playerRight; 
	public bool playerLeft; 

	// Use this for initialization
	void Start () {
		//declare that the gamemanager object is the instance
		instance = this; 

		//the game doesn't start until the ball is launched
		gameStart = false; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
