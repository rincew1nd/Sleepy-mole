using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Goal_manager : MonoBehaviour {


	public GUIText nextLvlText;
	public GameObject exitObject;
	public List<GameObject>Goal_blocks = new List<GameObject>();
	public bool isOpen;
	public void Goals_check()
	{
		if (Goal_blocks.Count == 0) {
						isOpen = true;
						nextLvlText.text = "\\No annoying mechs here nowrrr!!\\ -- He squealed -- \\But I can sense moarrr...\\";
						
				} else {
			isOpen = false;
				}
				
	}
	void Update()
	{
		Goals_check ();
	}

}
