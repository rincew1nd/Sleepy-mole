using UnityEngine;
using System.Collections;

public class Change_Position_Animation : MonoBehaviour {
		
	public float deltaPosition;
	public float speedX;
	public float speedY;
	private float i;
	private Vector3 movingVector;
	private Vector3 defaultPosition;
		
	void Start () {
		defaultPosition = transform.position;
	}

	void Update () {
		if(i < deltaPosition) movingVector = new Vector3 (speedX, speedY, 0);
		if (i > deltaPosition) movingVector = new Vector3 (-speedX, -speedY, 0);
		i += 0.01f;
		if (i > deltaPosition*2) {
			i = 0;
			transform.position = defaultPosition;
		} else {
			transform.position += movingVector;
		}
	}
}
