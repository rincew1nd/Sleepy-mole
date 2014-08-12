using UnityEngine;
using System.Collections;

public class noise : MonoBehaviour {

	public GameObject dummy;

	void Start() {
		dummy.renderer.enabled = false;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		audio.Play();
		dummy.renderer.enabled = true;
	}
	void OnTriggerExit2D (Collider2D col)
	{
		audio.Stop ();
		dummy.renderer.enabled = false;
	}
}