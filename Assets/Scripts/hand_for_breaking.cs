using UnityEngine;
using System.Collections;

public class hand_for_breaking : MonoBehaviour {

	public int side = 0; // 1-Up, 2-Down, 3-Left, 4-Right
	private Vector3 handPosition;
	public character_controller CharCon;

	void Update () {
		handPosition = CharCon.transform.position;

		if (Input.GetAxis ("Vertical") > 0.001 && side != 2)
		{
			side = 1;
			handPosition.y += 0.7f;
		}
		if (Input.GetAxis ("Vertical") < -0.001 && side != 1)
		{
			side = 2;
			handPosition.y += -0.7f;
		}
		if (Input.GetAxis ("Vertical") <= 0.001 && Input.GetAxis ("Vertical") >= -0.001)
		{
			side = (CharCon.facingRight) ? 4 : 3;
			handPosition.x += 0.7f;
		}

		transform.position = handPosition;
		if (Input.GetKey(KeyCode.B) && !audio.isPlaying) audio.Play();
		if (!Input.GetKey(KeyCode.B) && audio.isPlaying) audio.Stop();
	}

	void OnTriggerStay2D (Collider2D collider)
	{
		if (Input.GetKey(KeyCode.B) && collider.gameObject.GetComponent<block_logic>().isBreakable)
			collider.gameObject.GetComponent<block_logic>().hp -= 1;
	}
}
