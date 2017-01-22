using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour {

	const int MOVING = 0;
	const int SHOOTING = 1;

	public float speed;
	public GameObject player;
	public int state = 0;

	public float health;
	public float damage;

	public float winDelay;
	public string nextLevel;
	private bool isDead = false;
	private float deadStamp;

	public GameObject singleShot;
	public GameObject multiShot;
	public GameObject enemySpawn;
	public float spawnDelay;
	private bool hasSpawned;
	private float spawnStamp;

	public float shotDelay;
	private float shotStamp;
	private bool hasShot;
	private int shotCount;

	ArrayList hotSpots = new ArrayList();
	public Vector3[] spots = new Vector3[4];
	public Vector3 nextSpot;
	public Vector3 lastSpot;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 4; i++) {
			hotSpots.Add (spots [i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead == false) {
			if (state == MOVING) {
				this.gameObject.transform.position = new Vector3 (
					this.gameObject.transform.position.x + speed * (nextSpot.x - lastSpot.x),
					this.gameObject.transform.position.y + speed * (nextSpot.y - lastSpot.y),
					this.gameObject.transform.position.z + speed * (nextSpot.z - lastSpot.z));
				if (nextSpot.x - lastSpot.x > 0) {
					if (this.gameObject.transform.position.x - nextSpot.x > 0) {
						state = SHOOTING;
					}
				} else {
					if (this.gameObject.transform.position.x - nextSpot.x < 0) {
						state = SHOOTING;
					}
				}
				if (hasSpawned == false) {
					spawnStamp = Time.time;
					spawnEnemy ();
					hasSpawned = true;
				} else if (hasSpawned == true && Time.time - spawnStamp > spawnDelay) {
					hasSpawned = false;
				}
			} else {
				if (hasShot == false) {
					shotStamp = Time.time;
					shoot (shotCount);
					shotCount++;
					hasShot = true;
				} else if (hasShot == true && Time.time - shotStamp > shotDelay) {
					hasShot = false;
				}
				if (shotCount >= 2) {
					shotCount = 0;
					lastSpot = nextSpot;
					nextSpot = chooseRandomHotSpot (lastSpot);
					state = MOVING;
				}
			}
		} else if (Time.time - deadStamp > winDelay) {
			SceneManager.LoadScene (nextLevel);
		}
	}

	Vector3 chooseRandomHotSpot(Vector3 current){
		hotSpots.Remove (current);
		Vector3 result = (Vector3) hotSpots[Random.Range(0,3)];
		hotSpots.Add (current);
		return result;
	}

	void spawnEnemy(){
		GameObject spawnClone = Instantiate (enemySpawn, this.gameObject.transform.position, Quaternion.identity);
		Destroy (spawnClone, 10);
	}

	void shoot(int shotValue){
		if (shotValue == 0 || shotValue == 2) {
			GameObject shotClone1 = Instantiate (multiShot, this.gameObject.transform.position, Quaternion.identity);
			GameObject shotClone2 = Instantiate (multiShot, this.gameObject.transform.position, Quaternion.identity);
			GameObject shotClone3 = Instantiate (multiShot, this.gameObject.transform.position, Quaternion.identity);
			Vector3 tempDir1 = (Vector2) player.transform.position +
				new Vector2(Random.Range(-50,50), Random.Range(-50,50)) -
				(Vector2) shotClone1.transform.position;
			tempDir1.Normalize ();
			Vector3 tempDir2 = (Vector2) player.transform.position +
				new Vector2(Random.Range(-50,50), Random.Range(-50,50)) -
				(Vector2) shotClone1.transform.position;
			tempDir2.Normalize ();
			Vector3 tempDir3 = (Vector2) player.transform.position +
				new Vector2(Random.Range(-50,50), Random.Range(-50,50)) -
				(Vector2) shotClone1.transform.position;
			tempDir3.Normalize ();
			shotClone1.GetComponent<Bullet> ().setDirection (tempDir1);
			shotClone2.GetComponent<Bullet> ().setDirection (tempDir2);
			shotClone3.GetComponent<Bullet> ().setDirection (tempDir3);
			Destroy (shotClone1, 3);
			Destroy (shotClone2, 3);
			Destroy (shotClone3, 3);
		} else if (shotValue == 1) {
			GameObject shotClone1 = Instantiate (singleShot, this.gameObject.transform.position, Quaternion.identity);
			Vector3 tempDir1 = (Vector2) player.transform.position +
				new Vector2(Random.Range(-20,20), Random.Range(-20,20)) -
				(Vector2) shotClone1.transform.position;
			tempDir1.Normalize ();
			shotClone1.GetComponent<Bullet> ().setDirection (tempDir1);
			Destroy (shotClone1, 3);
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
		if(health <= 0 && isDead == false) {
			die();
		}
	}

	void die() {// :(
		isDead = true;
		deadStamp = Time.time;
	}

	public float getHealth(){
		return health;
	}
}
