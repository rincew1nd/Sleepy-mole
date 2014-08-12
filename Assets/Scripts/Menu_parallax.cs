using UnityEngine;
using System.Collections;

public class Menu_parallax : MonoBehaviour {

	private Vector3 defaultPosition;
	public int speed;

	void Srart() {
	}

	void Update () {
		defaultPosition = transform.position;
		defaultPosition.x = Input.mousePosition.x/speed;
		transform.position = defaultPosition;
	}
}
