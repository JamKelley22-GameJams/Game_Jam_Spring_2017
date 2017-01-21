using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
	public int health;
	public float moveSpeed;
	public float posX;
	public float posY;
	public float cumPosX = 0, cumPosY = 0;

	Transform player;

	private Vector3 moveDir;


	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		moveToPlayer ();
	}

	public void takeDamage(int damage) {
		health -= damage;
		if(health <= 0) {
			die();
		}
	}

	void die() {
		Destroy (this.gameObject);
	}

	public void moveToPlayer() {

		transform.position = Vector3.MoveTowards (transform.position,player.transform.position,moveSpeed * Time.deltaTime);

		/*

		posX = Time.deltaTime * moveSpeed;
		posY = Time.deltaTime * moveSpeed;

		cumPosX = this.gameObject.transform.position.x + posX;
		cumPosY = this.gameObject.transform.position.y + posY; 
		//moveDir = player.position - this.gameObject.transform.position;
		moveDir = new Vector3 (cumPosX,cumPosY,0);
		//this.gameObject.transform.LookAt (player.transform.position,Vector3.left);

		this.gameObject.transform.position = moveDir;
		*/


	}
}


