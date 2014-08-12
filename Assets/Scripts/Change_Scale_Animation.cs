using UnityEngine;
using System.Collections;

public class Change_Scale_Animation : MonoBehaviour {
	
	public float deltaScale;
	public float scaleX;
	public float scaleY;
	private float i;
	private Vector3 scaleVector;
	private Vector3 defaultScale;
	
	void Start () {
		defaultScale = transform.localScale;
	}
	
	void Update () {
		if(i < deltaScale) scaleVector = new Vector3 (scaleX, scaleY, 0);
		if (i > deltaScale) scaleVector = new Vector3 (-scaleX, -scaleY, 0);
		i += 0.01f;
		if (i > deltaScale*2) {
			i = 0;
			transform.localScale = defaultScale;
		} else {
			transform.localScale += scaleVector;
		}
	}
}
