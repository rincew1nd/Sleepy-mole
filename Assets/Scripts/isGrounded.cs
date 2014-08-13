using UnityEngine;
using System.Collections;

public class isGrounded : MonoBehaviour {

	public character_controller CharCon;
	
	void OnTriggerStay2D (Collider2D other)
	{
			if (CharCon.isGrounded == false)
				CharCon.isGrounded = true;
	}
}
