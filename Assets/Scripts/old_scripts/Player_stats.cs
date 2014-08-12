using UnityEngine;
using System.Collections;

public class Player_stats : MonoBehaviour {


	public int score;
	public bool isAlive;

	public GUIText score_board;
	public GUIText game_over;
	// Use this for initialization
	void Start () {
		isAlive = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!isAlive)
		{
			game_over.text="Failure!";
			Death();
		}
		else
		{
			game_over.text="";
		}
	}
	void Death()
	{
		Destroy (gameObject);

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Deathtrap") {
			isAlive=false;
				}
	}
	void LateUpdate()
	{

	}
}
