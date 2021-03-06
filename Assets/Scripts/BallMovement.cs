﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

	public Rigidbody2D rb; 

	public Transform player; 

	Vector2 vel;

	public float moveVelX; 

	public float moveVelY; 

	bool gameStart;  

	// Use this for initialization
	void Start () {
		//This sets that the ball will move upwards every time when launched
		vel.y = moveVelY;

		//The game will randomly decide which direction the ball will launch
		int rndNum = Random.Range (0, 2);

		//If the random number is 0, launch right. If it's 1, launch left. 
		if (rndNum == 0) {
			vel.x = moveVelX;
		} else if (rndNum == 1) {
			vel.x = -moveVelX;
		}

	}
	
	// Update is called once per frame
	void Update () {

		//this code saves us some trouble of having to type out the entire instance
		gameStart = GameManager.instance.gameStart;

		//When the game hasn't started yet, the ball will follow the player. 
		//The ball will also take into account which direction the player is moving when held so it will launch in the input direction when game starts.
		if (!gameStart) {
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + .45f, transform.position.z);
			if (GameManager.instance.playerLeft == true) {
				vel.x = -moveVelX;
			} else if (GameManager.instance.playerRight == true) {
				vel.x = moveVelX;
			}
		}

		//This code updates the changes made to the ball's velocity when interacting with other objects
		rb.MovePosition ((Vector2)transform.position + vel * Time.deltaTime);

		//if the ball's Y position is less than -5.5, then game over 
		if (transform.position.y <= -5.5f) {
			GameManager.instance.gameOver = true;
		}

	}

	void OnCollisionEnter2D(Collision2D coll){

		//When the ball hits a side wall, the x velocity with reverse to make it seem like it bounced
		if (coll.gameObject.tag == "Wall") {
			vel.x *= -1f;
		}

		//When the ball hits the roof, reverse the y velocity
		if (coll.gameObject.tag == "Roof") {
			vel.y *= -1f; 
		}

		//Reverse the y velocity when the ball hits teh player
		if (coll.gameObject.tag == "Player") {
			vel.y *= -1f;
		}

		//When the right or left side of a brick is hit, reverse the x velocity
		if (coll.gameObject.tag == "Left" || coll.gameObject.tag == "Right") {
			vel.x *= -1f;
		}

		//When the ball hits the bottom or top of a brick, reverse the y velocity
		if (coll.gameObject.tag == "Brick") {
			vel.y *= -1f;
		}

		//When the player's sides are hit, reverse the x velocity and y velocity to guarantee it goes up
		if (coll.gameObject.tag == "PLeft" || coll.gameObject.tag == "PRight") {
			vel.x *= -1f; 
			vel.y *= -1f; 
		}

	}
}
