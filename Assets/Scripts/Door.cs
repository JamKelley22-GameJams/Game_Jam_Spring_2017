using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public int enemyNum;
	public Vector2 direction;
	public float distance;
	public float playerDistance;
	private GameObject player;
	private bool inDoor;
	public Sprite open;
	public Sprite closed;
	public int nextRoomNum;

	// Use this for initialization
	void Start () {
		inDoor = false;
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (inDoor == true) {
			Camera.main.transform.position = new Vector3 (
				Camera.main.transform.position.x + direction.x * distance,
				Camera.main.transform.position.y + direction.y * distance, Camera.main.transform.position.z);
			player.transform.position = new Vector3 (
				player.transform.position.x + direction.x * playerDistance,
				player.transform.position.y + direction.y * playerDistance,
				player.transform.position.z);
			player.GetComponent<Movement> ().changeRoomNum (nextRoomNum);
			inDoor = false;
		}
		if (enemyNum == 0) {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = open;
		} else {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = closed;
		}
	}

	public void doorDeath(){
		enemyNum--;
	}

	void OnTriggerStay2D(Collider2D other){
		if (enemyNum == 0 && other.gameObject.tag.Equals("Player")) {
			inDoor = true;
		}
	}
}
