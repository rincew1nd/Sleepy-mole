using UnityEngine;
using System.Collections;

public class rotating_aim : MonoBehaviour {

	public GameObject up;
	public GameObject side;
	public GameObject down;
	// Use this for initialization
	void Start () {
	
		up.SetActive(false);
		side.SetActive(false);
		down.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
						up.SetActive (true);
						down.SetActive (false);
						side.SetActive (false);
				} else if (Input.GetKey (KeyCode.DownArrow)) {
						up.SetActive (false);
						down.SetActive (true);
						side.SetActive (false);
				} else if (Input.GetKey (KeyCode.P)) {
						up.SetActive (false);
						down.SetActive (false);
						side.SetActive (true);
				} else 
				{
			up.SetActive (true);
			down.SetActive (true);
			side.SetActive (true);
		}
		
	}
}
