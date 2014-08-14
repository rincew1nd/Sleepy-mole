using UnityEngine;
using System.Collections;

public class scene_logic : MonoBehaviour {
	
	public int score = 0;
	public int max_score = 0;
	public float timer = 0f;
	public static int level = 1;
	public int level_dummy
	{
		get { return level; }
		set { level = value; }
	}
	
	void Update () {
		timer = Time.time;
	}

	public void sceneReset() {
		Application.LoadLevel ("test_level"+level);
	}

	void OnGUI() {
		GUI.Box (new Rect (Screen.width/2-90, 0, 90, 50), "Score\n" + score + "/" + max_score);
		GUI.Box (new Rect (Screen.width/2, 0, 90, 50), "Time\n" + timer);
		if(GUI.Button (new Rect (Screen.width-60,0,60,25), "RESET")) sceneReset();
		if (GameObject.Find("character").GetComponent<character_controller>().isDead)
		{
			GUI.Box (new Rect (Screen.width/2-200, Screen.height/2-200, 400, 400), "GAME OVER");
			if(GUI.Button (new Rect (Screen.width/2-35, Screen.height/2-15, 70, 30), "RESTART"))
				sceneReset();
		}
	}
}
			   
