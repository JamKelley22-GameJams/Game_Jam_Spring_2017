using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

	public Vector2 mousePos; //variable for the mouse position
	public GameObject emptyMouse;
	public float mouseValue;
	public int maxX;
	public int maxY;
	public Vector3 mousePos2;

	public GameObject bullet;
	private GameObject tempBullet;

	// Use this for initialization
	void Start () {
		mousePos = new Vector2 (0, 0);
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			shoot ();
		}

		//mousePos =  ScreenToWorldPoint(Input.mousePosition);


		///*
		mousePos = new Vector2(Input.mousePosition.x - 210, Input.mousePosition.y - 150);

		if (mousePos.x > maxX) {
			mousePos = new Vector2 (maxX, mousePos.y);
		} else if (mousePos.x < -maxX) {
			mousePos = new Vector2 (-maxX, mousePos.y);
		}
		if (mousePos.y > maxY) {
			mousePos = new Vector2 (mousePos.x, maxY);
		} else if (mousePos.y < -maxY) {
			mousePos = new Vector2 (mousePos.x, -maxY);
		}

		emptyMouse.transform.position = new Vector3 (mousePos.x / mouseValue, mousePos.y / mouseValue, 0);
		this.gameObject.transform.LookAt (emptyMouse.transform.position);

		if (mousePos.x > 0) {
			GetComponent<SpriteRenderer> ().flipX = true;
			this.gameObject.transform.eulerAngles = new Vector3(0, 0, -this.gameObject.transform.rotation.eulerAngles.x);
		} else {
			GetComponent<SpriteRenderer> ().flipX = false;
			this.gameObject.transform.eulerAngles = new Vector3(0, 0, this.gameObject.transform.rotation.eulerAngles.x);
		}
		//*/
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
