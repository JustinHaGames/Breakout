using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D coll){
		//If the brick collides with the ball, destroy the brick and add a point
		if (coll.gameObject.tag == "Ball") {
			GameManager.instance.score += 1; 
			GameManager.instance.brickHit = true; 
			Destroy (gameObject);
		}
	}
}
