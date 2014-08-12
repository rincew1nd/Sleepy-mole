using UnityEngine;
using System.Collections;

public class ScriptName : MonoBehaviour {

	public string scriptName;
	public GUIText output;

	// Use this for initialization
	void Start () {
		if (scriptName == "") {
			scriptName = "ScriptName";
				}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (scriptName == "ScriptName") {
			output.text = "Nothing to do here...";
			this.enabled = false;
				}
	}
}
