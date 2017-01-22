using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour {
	public float health;
	public float moveSpeed;
	public float posX;
	public float posY;
	public float cumPosX = 0, cumPosY = 0;
	public float damage;

	Transform player;

	private Vector3 moveDir;

	void Awake() {// IDK what awake does but it was in the tutoral lol
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

		moveToPlayer ();
	}

	void OnTriggerStay2D(Collider2D other) { //This will do ticks of damage every frame, however it stops until the player moves again at about 20 frames
		//Debug.Log (other);
		if(other.gameObject.tag.Equals("Player")) {
			other.gameObject.GetComponent<Player> ().takeDamage(damage);
		}
		//Destroy (this.gameObject);
	}

	public void takeDamage(float damage) {//death, damage, pain
		health -= damage;
		this.gameObject.GetComponentInChildren<Fade>().fade();
		this.gameObject.GetComponent<GUIscript> ().takeDamage ();
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

	public float getHealth(){
		return health;
	}
}


