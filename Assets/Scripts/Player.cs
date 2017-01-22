using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float health; //has to be a relitivly high num, cuz damage in done per frame touching

	public bool hasWaveGun;
	public bool hasBeamGun;
	public bool hasWeirdGun;

	public GameObject waveGun;
	public GameObject beamGun;
	public GameObject weirdGun;

	public GameObject waveGunS;
	public GameObject beamGunS;
	public GameObject weirdGunS;

	void Start () {
		
	}

	void Update () {
		
	}

	public void takeDamage(float damage) {//argggggggghhhhhhh
		health -= damage;
		if(health < 0) {
			Destroy (this.gameObject);
			Debug.Log ("KFZoo creatures ate you :(");
			Global.playerAlive = false; //Idk how to do global vars
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag.Equals("Beam Gun")) {
			Debug.Log ("Found Beam Gun");
			beamGun.SetActive(true);
			waveGun.SetActive(false);
			weirdGun.SetActive(false);
			hasBeamGun = true;
			hasWaveGun = false;
			hasWeirdGun = false;

			if(hasWaveGun) {
				
			}
			if(hasWeirdGun) {

			}
		}
		if(other.gameObject.tag.Equals("Wave Gun")) {
			Debug.Log ("Found Wave Gun");
			beamGun.SetActive(false);
			waveGun.SetActive(true);
			weirdGun.SetActive(false);
			hasBeamGun = false;
			hasWaveGun = true;
			hasWeirdGun = false;
		}
		if(other.gameObject.tag.Equals("Weird Gun")) {
			Debug.Log ("Found Weird Gun");
			beamGun.SetActive(false);
			waveGun.SetActive(false);
			weirdGun.SetActive(true);
			hasBeamGun = false;
			hasWaveGun = false;
			hasWeirdGun = true;
		}
	}
}
