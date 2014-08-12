using UnityEngine;
using System.Collections;

public class Aiming_new : MonoBehaviour {
	int  aim_dir;
	RaycastHit2D rcHit;

	// Use this for initialization
	void Start () {
		aim_dir = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			aim_dir = 1;

		

			
		}
		else if (Input.GetKey (KeyCode.DownArrow)) 
		{
			aim_dir = -1;




		}
		else 
		{
			aim_dir=0;

		}
	//	gameObject.transform.position = target_dir;
	
	}


		
}
