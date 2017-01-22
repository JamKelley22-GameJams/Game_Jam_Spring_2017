using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpaca : MonoBehaviour {

	public float speed;
	public GameObject player;
	public bool state;

	public float health;
	public float damage;

	public GameObject doorEnter;
	public GameObject doorExit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (state) {
			if (this.gameObject.transform.position.y < player.transform.position.y + speed &&
				this.gameObject.transform.position.y > player.transform.position.y - speed) {
				state = false;
			} else if (this.gameObject.transform.position.y > player.transform.position.y) {
				this.gameObject.transform.position = new Vector3 (
					this.gameObject.transform.position.x,
					this.gameObject.transform.position.y - speed,
					this.gameObject.transform.position.z);
			} else if (this.gameObject.transform.position.y < player.transform.position.y) {
				this.gameObject.transform.position = new Vector3 (
					this.gameObject.transform.position.x,
					this.gameObject.transform.position.y + speed,
					this.gameObject.transform.position.z);
			}
		} else {
			if (this.gameObject.transform.position.x < player.transform.position.x + speed &&
				this.gameObject.transform.position.x > player.transform.position.x - speed) {
				state = true;
			} else if (this.gameObject.transform.position.x > player.transform.position.x) {
				this.gameObject.transform.position = new Vector3 (
					this.gameObject.transform.position.x - speed,
					this.gameObject.transform.position.y,
					this.gameObject.transform.position.z);
				this.gameObject.GetComponent<SpriteRenderer> ().flipX = true;
			} else if (this.gameObject.transform.position.x < player.transform.position.x) {
				this.gameObject.transform.position = new Vector3 (
					this.gameObject.transform.position.x + speed,
					this.gameObject.transform.position.y,
					this.gameObject.transform.position.z);
				this.gameObject.GetComponent<SpriteRenderer> ().flipX = false;
			}
		}
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
		doorEnter.GetComponent<Door>().doorDeath();
		doorExit.GetComponent<Door>().doorDeath();
		Destroy (this.gameObject);
	}

	public float getHealth(){
		return health;
	}
}
