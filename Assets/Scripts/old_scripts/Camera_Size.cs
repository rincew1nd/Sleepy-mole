using UnityEngine;
using System.Collections;

public class Camera_Size : MonoBehaviour {

	public float PixelToUnits_Scale;
	// Use this for initialization
	void Start () {
	
		gameObject.camera.orthographicSize = (Screen.height/2.0f)/PixelToUnits_Scale/2;
	}
	
	// Update is called once per frame
	void Update () {
	


	}
}
