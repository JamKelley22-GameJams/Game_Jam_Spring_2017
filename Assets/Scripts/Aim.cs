using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

	const int LEFT = 0;
	const int DOWN = 1;
	const int RIGHT = 2;
	const int UP = 3;

	public Vector3 mousePos; //variable for the mouse position
	public GameObject emptyMouse;

	public GameObject bullet;
	private GameObject tempBullet;

	private float xScale;

	public float shootDelay;
	private bool hasShot;
	private float shotStamp;

	public GameObject player;
	public Sprite[] sprites = new Sprite[4];

	void Start () {
		mousePos = new Vector3 (0, 0, 0);
		Cursor.visible = false;
		xScale = this.gameObject.transform.localScale.x;
		hasShot = false;
	}

	void Update () {
		checkShoot ();
		checkMouse ();
		checkRotation ();
	}

	private void checkShoot(){
		if (Input.GetMouseButton (0) && Time.time - shotStamp > shootDelay) {
			shoot ();
			hasShot = true;
		}
		if (hasShot == true) {
			shotStamp = Time.time;
			hasShot = false;
		}
	}

	private void checkMouse(){
		mousePos =  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10.0f));

		emptyMouse.transform.position = mousePos;
		this.gameObject.transform.LookAt (emptyMouse.transform.position);

		if (mousePos.x > this.gameObject.transform.position.x) {
			this.transform.localScale = new Vector3 (-xScale, this.gameObject.transform.localScale.y, 1);
			this.gameObject.transform.eulerAngles = new Vector3(0, 0, -this.gameObject.transform.rotation.eulerAngles.x);
		} else {
			this.transform.localScale = new Vector3 (xScale, this.gameObject.transform.localScale.y, 1);
			this.gameObject.transform.eulerAngles = new Vector3(0, 0, this.gameObject.transform.rotation.eulerAngles.x);
		}
	}

	private void checkRotation(){
		if (getDirection ().x <= -Mathf.Sqrt (2) / 2) {
			player.GetComponent<SpriteRenderer> ().sprite = sprites [LEFT];
		} else if (getDirection ().x >= Mathf.Sqrt (2) / 2) {
			player.GetComponent<SpriteRenderer> ().sprite = sprites [RIGHT];
		} else if (getDirection ().y > Mathf.Sqrt (2) / 2) {
			player.GetComponent<SpriteRenderer> ().sprite = sprites [UP];
		} else if (getDirection ().y < -Mathf.Sqrt (2) / 2) {
			player.GetComponent<SpriteRenderer> ().sprite = sprites [DOWN];
		}
	}

	private void shoot (){
		tempBullet = Instantiate (bullet, this.gameObject.transform.position, Quaternion.identity);
		Destroy (tempBullet, 3);
	}

	public Vector3 getDirection(){
		Vector3 dir = emptyMouse.transform.position - this.gameObject.transform.position;
		dir.Normalize ();
		return dir;
	}
}
