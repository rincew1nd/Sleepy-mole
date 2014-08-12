using UnityEngine;
using System.Collections;

public class Local_aims : MonoBehaviour {


	public GameObject current_aim=null;
	public bool aim=false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisderEnter2D (Collider2D other)
	{
		aim = true;
		if (other.tag == "Block_dest") {
			other.tag="Aimed";
			current_aim=GameObject.FindGameObjectWithTag("Aimed");
				}
	}
	void OnColliderExit2D (Collider2D other)
	{
		aim = false;
		if (other.tag == "Aimed") {
			other.tag = "Block_dest";
				current_aim=null;
				}
	}
}
