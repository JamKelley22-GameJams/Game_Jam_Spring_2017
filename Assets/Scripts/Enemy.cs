using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public int health;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void takeDamage(int damage) {
		health -= damage;
		if(health <= 0) {
			die();
		}
	}

	void die() {
		Destroy (this.gameObject);
	}
}
