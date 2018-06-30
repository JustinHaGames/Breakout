using System.Collections;
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

		if (coll.gameObject.tag == "Player") {
			vel.y *= -1f;
		}

		if (coll.gameObject.tag == "Left" || coll.gameObject.tag == "Right") {
			vel.x *= -1f;
		}

		if (coll.gameObject.tag == "Brick") {
			vel.x *= -1f;
		}

	}
}
