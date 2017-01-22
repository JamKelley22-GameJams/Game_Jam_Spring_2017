using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float moveSpeed;
	private float posX = 0, posY = 0;
	public float cumPosX = 0, cumPosY = 0;
	public float maxPos = 100;
	public float roomOffset = 50;//The distance of max room pos to the actual side of room
	public bool smoothMovement = false;
	int roomNum = 0;
	float[][] roomMaxMin;

	void Awake() {
			//Room sizes will replace maxPos
			//{maxY,minY,maxxX,minX}
			roomMaxMin = new float[][] {
			new float[]{maxPos,-maxPos, maxPos,-maxPos},
			new float[]{roomOffset + 3 * maxPos,maxPos + roomOffset, maxPos,-maxPos},
			new float[]{2 * roomOffset + 5 * maxPos, 2 * roomOffset + 3 * maxPos, 4*maxPos, -maxPos},
			new float[]{ 2 * roomOffset + 8 * maxPos, 2 * roomOffset + 3 * maxPos,9*maxPos+1*roomOffset,4*maxPos+1*roomOffset},
			new float[]{7*maxPos+3*roomOffset, 5*maxPos+3*roomOffset, 4*maxPos, -maxPos}};
	}
	void Update()
	{
		if(smoothMovement) {
			posX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
			posY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
		}
		else {
			posX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
			posY = Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed;
		}
		
		cumPosX = this.gameObject.transform.position.x + posX;
		cumPosY = this.gameObject.transform.position.y + posY; 

		if(cumPosX > roomMaxMin[roomNum][2]) {
			cumPosX = roomMaxMin[roomNum][2];
		}
		if(cumPosX < roomMaxMin[roomNum][3]) {
			cumPosX = roomMaxMin[roomNum][3];
		}

		if(cumPosY > roomMaxMin[roomNum][0]) {
			cumPosY = roomMaxMin[roomNum][0];
		}
		if(cumPosY < roomMaxMin[roomNum][1]) {
			cumPosY = roomMaxMin[roomNum][1];
		}


		this.gameObject.transform.position = new Vector2 (cumPosX,cumPosY);
		
	}
	public void changeRoomNum(int num) {
		roomNum = num;
	}

	public float[] getRoomMinMax(){
		float[] temp = new float[4];
		for (int i = 0; i < 4; i++) {
			temp [i] = roomMaxMin [roomNum] [i];
		}
		return temp;
	}
}
