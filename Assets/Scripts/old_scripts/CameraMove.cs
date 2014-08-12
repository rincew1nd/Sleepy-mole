using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public GameObject objChase = null;
	public float vertical_shift;
	public float timeDamp;
	Vector3 velocity = Vector3.zero;
	Vector3 tmp;
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () {
		/*tmp = new Vector3 (objChase.transform.position.x, gameObject.transform.position.y, -10);
		/*if (objChase.transform.position.x > transform.position.x + bound.x)	
		else if(objChase.transform.position.x < transform.position.x - bound.x)tmp.x -= cameraSpeed * Time.deltaTime;
		if (objChase.transform.position.y > transform.position.y + bound.y)	tmp.y += cameraSpeed * Time.deltaTime;
		else if(objChase.transform.position.x < transform.position.y - bound.y) tmp.y -= cameraSpeed * Time.deltaTime;*/
		/*tmp = Vector3.SmoothDamp(transform.position,tmp,ref velocity, timeDamp);
		transform.position = tmp;*/

		Vector3 targetPos = new Vector3(objChase.transform.position.x,gameObject.transform.position.y,-10);
		gameObject.transform.position= targetPos;
	}
}
