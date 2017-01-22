using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showCOntrol : MonoBehaviour {

	public float fadeSpeed;
	bool isFadingIn = false;
	bool isFadingOut = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(isFadingIn) {
			this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,this.gameObject.GetComponent<SpriteRenderer>().color.a + fadeSpeed);
			if(this.gameObject.GetComponent<SpriteRenderer>().color.a == 1) {
				isFadingIn = false;
			}
		}


		if(isFadingOut) {
			this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,this.gameObject.GetComponent<SpriteRenderer>().color.a - fadeSpeed);
			if(this.gameObject.GetComponent<SpriteRenderer>().color.a == 0) {
				isFadingIn = false;
			}
		}
	}

	public void fade() {
		isFadingIn = true;
		this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag.Equals ("Player")) {
			Debug.Log ("Fade IN");
			isFadingIn = true;
		}
	}
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag.Equals ("Player")) {
			Debug.Log ("Fade OUT");
			isFadingOut = true;
		}
	}
}
