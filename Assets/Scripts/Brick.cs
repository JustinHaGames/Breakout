using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D coll){
		//If the brick collides with the ball, destroy the ball
		if (coll.gameObject.tag == "Ball") {
			Destroy (gameObject);
		}
	}
}
