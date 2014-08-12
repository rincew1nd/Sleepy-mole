using UnityEngine;
using System.Collections;

public class moving_platform : MonoBehaviour {

	public Vector3 movingVector;
	public string side;
	public float speed;
	public float deltaPosition;
	private float i;

	void Start() {
		if (side == "horizontal") movingVector = new Vector3(speed,0,0);
		if (side == "vertical") movingVector = new Vector3(0,speed,0);
	}

	void Update () {
		if(i < deltaPosition)
		{
			transform.position += movingVector;
		}
		if (i >= deltaPosition) transform.position -= movingVector;
		i += speed;
		if (i > deltaPosition*2) i = 0;
	}
}
