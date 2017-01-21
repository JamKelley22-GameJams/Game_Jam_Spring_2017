using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

	public float fadeSpeed;
	bool isFading = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isFading) {
			this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,this.gameObject.GetComponent<SpriteRenderer>().color.a - fadeSpeed);
		}
		if(this.gameObject.GetComponent<SpriteRenderer>().color.a == 0) {
			isFading = false;
		}
	}

	public void fade() {
		isFading = true;
		this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
	}
}
