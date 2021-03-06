﻿using UnityEngine;
using System.Collections;

public class canMoveSide : MonoBehaviour {

	public character_controller CharCon;
	public string side;
	
	void OnTriggerStay2D (Collider2D other)
	{
		if (side == "left") {
			if (CharCon.canMoveLeft == true)
				CharCon.canMoveLeft = false;
		} else if (side == "jump") {
			if (CharCon.canJump == true)
				CharCon.canJump = false;
		} else if (side == "right"){
			if (CharCon.canMoveRight == true)
				CharCon.canMoveRight = false;
		}
	}
	
	void OnTriggerExit2D (Collider2D other)
	{
		if (side == "left") {
			if (CharCon.canMoveLeft == false)
				CharCon.canMoveLeft = true;
		} else if (side == "jump") {
			if (CharCon.canJump == false)
				CharCon.canJump = true;
		} else if (side == "right"){
			if (CharCon.canMoveRight == false)
				CharCon.canMoveRight = true;
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (side == "left") {
			CharCon.transform.position += new Vector3(0.01f,0,0);
		} else if (side == "right"){
			CharCon.transform.position += new Vector3(-0.01f,0,0);
		}
	}
}
