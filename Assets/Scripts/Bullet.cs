using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int damage;
	public float speed;
	public Vector2 direction;

	void Start () {
	}

	void Update () {
			this.gameObject.transform.position = new Vector3 (
				this.gameObject.transform.position.x + direction.x * speed,
				this.gameObject.transform.position.y + direction.y * speed, 0);
	}

	public void setDirection(Vector2 dir){
		direction = dir;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag.Equals("Player")) {
			other.gameObject.GetComponent<Player> ().takeDamage (damage);
			Destroy (this.gameObject);
		}

	}
}
