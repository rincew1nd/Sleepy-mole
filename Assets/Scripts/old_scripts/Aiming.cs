using UnityEngine;
using System.Collections;

public class Aiming : MonoBehaviour {
	/*public GameObject player;
	public GameObject up_at;
	public GameObject side_at;
	public GameObject down_at;*/

	Vector2 target_dir;
	public bool aim;
	public int attack_dir;

	public GameObject block_damaging;
	block_destruction b_des;

	public bool punching;
	public bool hitting;

	// Use this for initialization
	void Start () {
		attack_dir = 0;
	}
	
	// Update is called once per frame
	void Update () {/*
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			attack_dir = 1;
			target_dir = up_at.transform.position;
				}
		else if (Input.GetKey (KeyCode.DownArrow)) 
		{
			attack_dir = -1;
			target_dir = down_at.transform.position;
		}
		else 
		{
			attack_dir=0;
			target_dir = side_at.transform.position;
		}
		gameObject.transform.position = target_dir;*/


		//gameObject.transform.position = target_dir;


		if (Input.GetKey (KeyCode.P)) 
		{
			punching = true;
			
			
		}
		else 
			punching = false;
		if ((punching)&&(!hitting)) {
			
			StartCoroutine ("Punch");
			hitting = true;
		}

	
	}
	void OnTriggerEnter2D(Collider2D other){

						aim = true;
		if (other.tag == "Block_dest") 
		{
			other.tag="Aimed";
			block_damaging = GameObject.FindGameObjectWithTag("Aimed");
			b_des = block_damaging.GetComponent<block_destruction> ();
			//block_damaging = GameObject.FindGameObjectWithTag("Aimed");
				}
		}
	void OnTriggerExit2D(Collider2D other){
		aim = false;
		if (other.tag == "Aimed") 
		{
			other.tag="Block_dest";
			b_des = null;
			block_damaging = null;
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
		b_des.health-=10;
	}
}
