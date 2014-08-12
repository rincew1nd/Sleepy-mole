using UnityEngine;
using System.Collections;

public class movingplatform : MonoBehaviour {

	public float i = 0;
	public Vector3 vector;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(i < 1.5f) vector = new Vector3 (0.01f, 0, 0);
		if (i > 1.5f) vector = new Vector3 (-0.01f, 0, 0);
		i += 0.01f;
		if (i > 3f)	i = 0;
		transform.position += vector;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		other.gameObject.transform.position += vector;
		}
}
