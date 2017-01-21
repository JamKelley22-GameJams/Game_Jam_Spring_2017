using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float health; //has to be a relitivly high num, cuz damage in done per frame touching




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
}
