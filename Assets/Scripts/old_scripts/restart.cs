using UnityEngine;
using System.Collections;

public class restart : MonoBehaviour {

	public int score;
	public bool isAlive;
	
	public GUIText score_board;
	public GUIText game_over;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.R))
						Application.LoadLevel (0);
		score_board.text = "Score: " + score.ToString();
	}
}
