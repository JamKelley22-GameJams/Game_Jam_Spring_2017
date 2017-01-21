using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int damage;
	public float speed;
	private Vector2 direction;

	// Use this for initialization
	void Start () {
			direction = GameObject.Find("Gun").GetComponent<Aim> ().getDirection ();
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.position = new Vector3 (
			this.gameObject.transform.position.x + direction.x * speed,
			this.gameObject.transform.position.y + direction.y * speed, 0);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag.Equals("Enemy")) {
			other.gameObject.GetComponent<Enemy> ().takeDamage (damage);
		}
		Destroy (this.gameObject);
	}
}
