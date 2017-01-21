using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {
	public static bool playerAlive = true; //Want other classes to know when player is dead, specifically Enemy class (state is decided in Player)
	public static bool waveGun;
	public static bool beamGun;
	public static bool weirdGun;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
