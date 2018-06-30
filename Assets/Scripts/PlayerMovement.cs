using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	//Connect the player's rigidbody to the code to apply the velocity
	public Rigidbody2D rb; 

	//A vector2 that will be applied to the rigidbody. We will be manipulating this vectors values 
	//and apply them to the player
	Vector2 vel; 

	//The speed that the player will move left to right
	public float moveVelX;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//Identify if left is being input with either the left arrow key or the A key
		bool left = Input.GetKey (KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
		//Identify if right is being input with either the right arrow key or the D key
		bool right = Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

		//This will launch the ball at the start of the game
		bool launch = Input.GetKeyDown (KeyCode.Space);

		//The game starts when the player launches the ball
		if (GameManager.instance.gameStart == false && launch) {
			GameManager.instance.gameStart = true; 
		}

		//This code applies the velocity to the player when their respected keys are pressed
		//If no keys are pressed, the velocity is 0 
		if (left) {
			vel.x = -moveVelX;
			GameManager.instance.playerLeft = true;
		}

		if (right) {
			vel.x = moveVelX;
			GameManager.instance.playerRight = true; 
		}

		if (!left && !right) {
			vel.x = 0; 
		}

		rb.MovePosition ((Vector2)transform.position + vel * Time.deltaTime);
	}
}
