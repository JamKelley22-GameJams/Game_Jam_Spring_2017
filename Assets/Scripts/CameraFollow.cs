using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private GameObject player;
	public float[] maxMin;

	// Use this for initialization
	void Start () {
		player = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		maxMin = player.GetComponent<Movement> ().getRoomMinMax();
		//x
		if (player.transform.position.x <= maxMin [3] + 75) {
			Camera.main.transform.position = new Vector3 (maxMin [3] + 75,
				Camera.main.transform.position.y,
				Camera.main.transform.position.z);
		} else if (player.transform.position.x > maxMin [2] - 75) {
			Camera.main.transform.position = new Vector3 (maxMin [2] - 75,
				Camera.main.transform.position.y,
				Camera.main.transform.position.z);
		} else {
			Camera.main.transform.position = new Vector3 (player.transform.position.x,
				Camera.main.transform.position.y,
				Camera.main.transform.position.z);
		}
		//y
		if (player.transform.position.y <= maxMin [1] + 75) {
			Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x,
				maxMin [1] + 75,
				Camera.main.transform.position.z);
		} else if (player.transform.position.y > maxMin [0] - 75) {
			Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x,
				maxMin [0] - 75,
				Camera.main.transform.position.z);
		} else {
			Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x,
				player.transform.position.y,
				Camera.main.transform.position.z);
		}
	}
}
