using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour {

    public bool Disable;
    public bool toAnotherScene;
    public Doors nextDoor;
    public int sceneName;

    private GameObject player;
    public void Transport()
    {
        if (Disable)
        {
            GameObject.Find("MainOutput").guiText.text = "Can't go there for now.";
        }
        else 
        {
            if (toAnotherScene)
            {
                Application.LoadLevel(sceneName);
            }
            else
            {
                player = GameObject.FindWithTag("Player");
                player.transform.position = nextDoor.transform.position + new Vector3(0f, 0.7f, 0f);
            }
        }
        
    }
	
	// Update is called once per frame
}