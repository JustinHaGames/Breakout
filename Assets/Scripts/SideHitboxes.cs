using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideHitboxes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D coll){
		//If the left and right hitboxes are on the bricks and not the player, it will destroy the brick and add 1 point
		if (coll.gameObject.tag == "Ball") {
			if (transform.parent.gameObject.tag == "Brick") {
				Destroy (transform.parent.gameObject);
				GameManager.instance.score += 1; 
			}
		}
	}

}
