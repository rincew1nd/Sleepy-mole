using UnityEngine;
using System.Collections;

public class level_doors : MonoBehaviour {
	
	private GameObject scene;
	
	void Start() {
		scene = GameObject.Find("scene_logic");
	}
	
	void OnTriggerEnter2D (Collider2D other){
		if(scene.GetComponent<scene_logic>().score == scene.GetComponent<scene_logic>().max_score && scene.GetComponent<scene_logic>().timer <= 60f)
		{
			scene.GetComponent<scene_logic>().level_dummy += 1;
			Application.LoadLevel ("test_level" + scene.GetComponent<scene_logic>().level_dummy);
		}
	}
}