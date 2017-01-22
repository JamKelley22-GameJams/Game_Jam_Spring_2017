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

	public GameObject pickUpWeapon;

	public bool inSpace = false;

	private string otherTag;

	void Start () {
		
	}

	void Update () {
		if(Input.GetMouseButtonDown(1) && inSpace) {
			if(otherTag.Equals("Beam_Gun")) {
				Debug.Log ("Found Beam Gun");
				beamGun.SetActive(true);
				waveGun.SetActive(false);
				weirdGun.SetActive(false);

				if(hasWaveGun) {
					waveGunS.SetActive(true);
				}
				if(hasWeirdGun) {
					weirdGunS.SetActive(true);
				}
				beamGunS.SetActive(false);

				hasBeamGun = true;
				hasWaveGun = false;
				hasWeirdGun = false;
			}
			if(otherTag.Equals("Wave_Gun")) {
				Debug.Log ("Found Wave Gun");
				beamGun.SetActive(false);
				waveGun.SetActive(true);
				weirdGun.SetActive(false);

				if(hasBeamGun) {
					beamGunS.SetActive(true);
				}
				if(hasWeirdGun) {
					weirdGunS.SetActive(true);
				}
				waveGunS.SetActive(false);

				hasBeamGun = false;
				hasWaveGun = true;
				hasWeirdGun = false;
			}
			if(otherTag.Equals("Weird_Gun")) {
				Debug.Log ("Found Weird Gun");
				beamGun.SetActive(false);
				waveGun.SetActive(false);
				weirdGun.SetActive(true);

				if(hasBeamGun) {
					beamGunS.SetActive(true);
				}
				if(hasWaveGun) {
					waveGunS.SetActive(true);
				}
				weirdGunS.SetActive(false);

				hasBeamGun = false;
				hasWaveGun = false;
				hasWeirdGun = true;
			}
		}
	}

	public void takeDamage(float damage) {//argggggggghhhhhhh
		health -= damage;
		this.gameObject.GetComponentInChildren<Fade>().fade();
		if(health < 0) {
			Destroy (this.gameObject);
			Debug.Log ("KFZoo creatures ate you :(");
			Global.playerAlive = false; //Idk how to do global vars
		}

	}

	void OnTriggerExit2D() {
		inSpace = false;
	}

	void OnTriggerStay2D(Collider2D other) {
		//Instantiate (pickUpWeapon, this.gameObject.transform.position, Quaternion.identity);
		if(other.gameObject.tag.Equals("Beam_Gun") || other.gameObject.tag.Equals("Wave_Gun") || other.gameObject.tag.Equals("Weird_Gun")) {
			inSpace = true;
			otherTag = other.gameObject.tag;
		}



	
	}

	public float getHealth(){
		return health;
	}

}
