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
		vel.y = moveVelY;
	}
	
	// Update is called once per frame
	void Update () {

		gameStart = GameManager.instance.gameStart;

		if (!gameStart) {
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + .45f, transform.position.z);
			if (GameManager.instance.playerLeft == true) {
				vel.x = -moveVelX;
			} else if (GameManager.instance.playerRight == true) {
				vel.x = moveVelX;
			}
		}
			


		rb.MovePosition ((Vector2)transform.position + vel * Time.deltaTime);

	}

	void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.tag == "Wall") {
			vel.x *= -1f;
		}

		if (coll.gameObject.tag == "Roof") {
			vel.y *= -1f; 
		}

	}
}
