using UnityEngine;
using System.Collections;

public class hand_position : MonoBehaviour {
	
	public character_controller CharCon;
	public Vector3 handPosition;
	public GameObject player;
	public GameObject aimed_block;
	Collider2D hand_col;
	block_destruction aim_bloc;
	public bool aim;
	public bool hitting;
	bool punching;
	bool destroyed;
	
	void Update () {
		hand_col=gameObject.GetComponent<BoxCollider2D>();
		if ((Input.GetKey (KeyCode.UpArrow))&&(Input.GetKey(KeyCode.P))) {
						hand_col.collider2D.transform.position = new Vector2 (player.transform.position.x, player.transform.position.y + 0.2f);
			punching=true;		
			
		} else if ((Input.GetKey (KeyCode.DownArrow))&&(Input.GetKey(KeyCode.P))) {

						hand_col.collider2D.transform.position = new Vector2 (player.transform.position.x, player.transform.position.y - 0.2f);
			punching=true;
			
			
				} else if (Input.GetKey (KeyCode.P)) {
						hand_col.collider2D.transform.position = new Vector2 (player.transform.position.x - (2*player.transform.lossyScale.x), player.transform.position.y);
			punching=true;
				} else {
			hand_col.collider2D.transform.position= new Vector2(player.transform.position.x,player.transform.position.y);
			punching=false;
		}
		if (punching)
						StartCoroutine ("Punch");
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		
       // Debug.Log(other.gameObject.name);
		if (other.tag == "Block_dest") {
			other.tag="Aimed";
			aimed_block = GameObject.FindGameObjectWithTag("Aimed");
			aim_bloc = aimed_block.GetComponent<block_destruction>();

			aim=true;
				}

    }
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Aimed") {
					other.tag="Block_dest";
						aim = false;
			aimed_block = null;
			aim_bloc = null;
				}
	}
	IEnumerator Punch()
	{
		yield return new WaitForSeconds(0.1f);
		if (aim) {
			Hit ();
		}
		Debug.Log ("hit");
		hitting = false;
	}
	void Hit()
	{
		aim_bloc.health-=10;
	}
}
