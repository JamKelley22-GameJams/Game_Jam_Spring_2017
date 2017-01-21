using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float moveSpeed;
	private float posX = 0, posY = 0;
	public float cumPosX = 0, cumPosY = 0;
	public float maxPos = 100;

	public int roomNum = 0;
	float[][] roomMaxMin;

	void Start() {
			roomMaxMin = new float[][] {
			new float[]{maxPos,-maxPos},
			new float[]{maxPos,-maxPos},
			new float[]{maxPos,-maxPos},
			new float[]{maxPos,-maxPos},
			new float[]{maxPos,-maxPos}};
	}
	void Update()
	{
		posX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
		posY = Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed;
		cumPosX = this.gameObject.transform.position.x + posX;
		cumPosY = this.gameObject.transform.position.y + posY; 

		if(cumPosX > roomMaxMin[roomNum][0]) {
			cumPosX = roomMaxMin[roomNum][0];
		}
		if(cumPosX < roomMaxMin[roomNum][1]) {
			cumPosX = roomMaxMin[roomNum][1];
		}

		if(cumPosY > roomMaxMin[roomNum][0]) {
			cumPosY = roomMaxMin[roomNum][0];
		}
		if(cumPosY < roomMaxMin[roomNum][1]) {
			cumPosY = roomMaxMin[roomNum][1];
		}


		this.gameObject.transform.position = new Vector2 (cumPosX,cumPosY);
		
	}
}
