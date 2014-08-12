using UnityEngine;
using System.Collections;


public class Exit_door : MonoBehaviour {
	Goal_manager g_m;
	public bool isOpen;
	bool playerEnter;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		if (playerEnter) {
			g_m = GameObject.FindGameObjectWithTag("Goal_manager").GetComponent<Goal_manager>();
			if(g_m.isOpen)isOpen=true;
						goExit (1);
				}
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
			if (other.tag == "Player") {
			playerEnter = true;
						}
		}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") {
						playerEnter = false;
				}
	}
	void goExit(int nextLvl)
	{
		if (isOpen)
						Application.LoadLevel (nextLvl);
				else
						g_m.nextLvlText.text = "\\No way... Arghh I hate this noise!\\ -- He groused";
		}
}
