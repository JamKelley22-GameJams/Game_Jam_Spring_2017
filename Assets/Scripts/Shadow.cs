using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour {

	public float yOff;
	public GameObject parent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (parent.transform.position.x,
			parent.transform.position.y + yOff,
			parent.transform.position.z);
	}
}
