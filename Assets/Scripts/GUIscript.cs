using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIscript : MonoBehaviour {

	private bool showBar;
	private float showStamp;
	private bool takingDamage;
	public float fadeDelay;
	public float xSize;
	public float ySize;
	public Texture image;
	public float xOffset;
	public float yOffset;

	private float maxHP;
	private float HP;

	// Use this for initialization
	void Start () {
		if (this.gameObject.tag.Equals ("Player")) {
			maxHP = this.gameObject.GetComponent<Player> ().getHealth ();
		} else if (this.gameObject.tag.Equals ("Enemy")) {
			maxHP = this.gameObject.GetComponent<Enemy> ().getHealth ();
		} else if (this.gameObject.tag.Equals ("Alpaca")) {
			maxHP = this.gameObject.GetComponent<Alpaca> ().getHealth ();
		} else if (this.gameObject.tag.Equals ("Boss")) {
			maxHP = this.gameObject.GetComponent<Boss> ().getHealth ();
		} else if (this.gameObject.tag.Equals ("Slime")) {
			maxHP = this.gameObject.GetComponent<Slime> ().getHealth ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.tag.Equals ("Player")) {
			HP = this.gameObject.GetComponent<Player> ().getHealth ();
		} else if (this.gameObject.tag.Equals ("Enemy")) {
			HP = this.gameObject.GetComponent<Enemy> ().getHealth ();
		} else if (this.gameObject.tag.Equals ("Alpaca")) {
			HP = this.gameObject.GetComponent<Alpaca> ().getHealth ();
		} else if (this.gameObject.tag.Equals ("Boss")) {
			HP = this.gameObject.GetComponent<Boss> ().getHealth ();
		} else if (this.gameObject.tag.Equals ("Slime")) {
			HP = this.gameObject.GetComponent<Slime> ().getHealth ();
		}
		if (takingDamage == false) {
			showStamp = Time.time;
		}
		if (takingDamage == true && Time.time - showStamp < fadeDelay) {
			showBar = true;
		} else {
			showBar = false;
			takingDamage = false;
		}
	}

	public void takeDamage(){
		takingDamage = true;
	}

	void OnGUI(){
		if (showBar) {
			GUI.DrawTexture (new Rect (
				new Vector2(Camera.main.WorldToScreenPoint (new Vector3(this.gameObject.transform.position.x,
					this.gameObject.transform.position.y, this.gameObject.transform.position.z)).x + xOffset,
					Screen.height - Camera.main.WorldToScreenPoint(new Vector3(this.gameObject.transform.position.x,
						this.gameObject.transform.position.y, this.gameObject.transform.position.z)).y + yOffset),
				new Vector2 (xSize * HP / maxHP, ySize)), image);
		}
	}
}
