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
	public float damage;

	Transform player;

	private Vector3 moveDir;

	public float amplitude;
	public float frequency;


	void Awake() {// IDK what awake does but it was in the tutoral lol
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		moveToPlayer ();

		this.transform.position = new Vector3(transform.position.x,transform.position.y + amplitude * Mathf.Sin(frequency * Time.time),transform.position.z);
	}

	void OnTriggerStay2D(Collider2D other) { //This will do ticks of damage every frame, however it stops until the player moves again at about 20 frames
		//Debug.Log (other);
		if(other.gameObject.tag.Equals("Player")) {
			other.gameObject.GetComponent<Player> ().takeDamage (damage);
		}
		//Destroy (this.gameObject);
	}

	public void takeDamage(int damage) {//death, damage, pain
		health -= damage;
		if(health <= 0) {
			die();
		}
	}

	void die() {// :(
		Destroy (this.gameObject);
	}

	public void moveToPlayer() { //Spent forever on this only to find a function that was easy 
		if(Global.playerAlive == true) {
			this.transform.position = Vector3.MoveTowards (transform.position,player.transform.position,moveSpeed * Time.deltaTime);

		}
	}
}


