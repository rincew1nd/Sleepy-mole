using UnityEngine;
using System.Collections;

public class block_logic : MonoBehaviour {

	public int hp = 50;
	public bool isBreakable = true;
	public bool isNoisy = false;

	void Update() {
		if (hp <= 0) DestroyObject(gameObject);
	}
}
