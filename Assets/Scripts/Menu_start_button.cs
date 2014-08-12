using UnityEngine;
using System.Collections;

public class Menu_start_button : MonoBehaviour {

	public Texture btntexture;

	/* Для дальнейшей загрузки уровней, устарело!
	void OnGUI()
	{
		if (GUI.Button (new Rect (30, 50, 20, 20), btntexture)) {
			Application.LoadLevel ("Sewers");
		}
	}
	*/

	void OnMouseDown() {
		Debug.Log ("Level loaded");
		Application.LoadLevel ("test_level1");
	}
}
