using UnityEngine;
using System.Collections;

public class block_logic : MonoBehaviour {

	public int hp = 50;
	public bool isBreakable = true;
	public bool isNoisy = false;
	private GameObject charcon;

	void Start() {
		if (isNoisy)
		{
			Debug.Log ("im noisy!");
			Debug.Log (gameObject.name);
			Instantiate(Resources.Load("Prefabs/Main/noisy_waves"), transform.position, Quaternion.identity);
		}
	}

	void Update() {
		if (hp <= 0)
		{
			charcon = GameObject.Find("character");
			charcon.GetComponent<character_controller>().canMoveLeft = true;
			charcon.GetComponent<character_controller>().canMoveRight = true;
			DestroyObject(gameObject);
		}
	}
}
