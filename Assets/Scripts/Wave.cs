using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	public int damage;
	public float speed;
	private Vector2 direction;

	public float fadeSpeed;
	private bool hasHit;

	public float growSpeed;

	private float angle;

	public bool decay;

	public int decayPerTic;

	void Start () {
		direction = GameObject.Find("Gun").GetComponent<Aim> ().getDirection ();
		hasHit = false;
		this.gameObject.transform.LookAt (GameObject.Find("Cursor").transform);
		angle = this.gameObject.transform.rotation.eulerAngles.x;
		if (direction.x >= 0) {
			this.gameObject.transform.eulerAngles = new Vector3(0, 0, -angle - 90);
		} else {
			this.gameObject.transform.eulerAngles = new Vector3(0, 0, angle + 90);
		}
	}

	void Update () {
		if (hasHit == true) {
			this.gameObject.GetComponent<SpriteRenderer> ().color = new Color 
				(1, 1, 1, this.gameObject.GetComponent<SpriteRenderer> ().color.a - fadeSpeed);
		}
		if (this.gameObject.GetComponent<SpriteRenderer> ().color.a <= 0 + fadeSpeed || damage <= 0) {
			Destroy (this.gameObject);
		}

		if (decay == true) {
			damage-= decayPerTic;
		}

		this.gameObject.transform.localScale = new Vector3 (
			this.gameObject.transform.localScale.x + growSpeed,
			this.gameObject.transform.localScale.y + growSpeed, 1);
		this.gameObject.transform.position = new Vector3 (
			this.gameObject.transform.position.x + direction.x * speed,
			this.gameObject.transform.position.y + direction.y * speed, 0);
	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.gameObject.tag.Equals("Enemy") && hasHit == false) {
			hasHit = true;
			other.gameObject.GetComponent<Enemy> ().takeDamage (damage);
		}
	}
}