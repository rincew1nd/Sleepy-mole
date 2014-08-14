using UnityEngine;
using System.Collections;

public class block_logic : MonoBehaviour {
	
	public int hp = 50;
	public bool isBreakable = true;
	public bool isNoisy = false;
	private GameObject charcon;
	private GameObject scene;
	
	void Start() {
		
		charcon = GameObject.Find("character");
		scene = GameObject.Find("scene_logic");
		
		if (isNoisy)
		{
			Debug.Log ("im noisy!");
			Debug.Log (gameObject.name);
			Instantiate(Resources.Load("Prefabs/Main/noisy_waves"), transform.position, Quaternion.identity);
			scene.GetComponent<scene_logic>().max_score++;
		}
	}
	
	void Update() {
		if (hp <= 0)
		{
			charcon.GetComponent<character_controller>().canMoveLeft = true;
			charcon.GetComponent<character_controller>().canMoveRight = true;
			
			if (isNoisy) scene.GetComponent<scene_logic>().score++;
			
			DestroyObject(gameObject);
		}
	}
}

