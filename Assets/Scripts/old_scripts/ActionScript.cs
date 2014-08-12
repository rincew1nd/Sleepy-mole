using UnityEngine;
using System.Collections;

public class ActionScript : MonoBehaviour
{
    public GUIText output;
	public bool action;

    private int actionCount;
    private bool doorUp;
    private bool doorDown;
    private Collider2D colUp;
    private Collider2D colDown;
    private string[] actionsList;
    private Collider2D[] colliderList;
    private string actionName;
    private bool readyToAction;
    // Use this for initialization
    void Start()
    {
		action = false;
        readyToAction = false;
        actionCount = 0;
        doorUp = false;
        doorDown = false;
        actionsList = new string[3];
        for (int i = 0; i < 3; i++)
        {
            actionsList[i] = "";
        }
        colliderList = new Collider2D[3];
    }

    // Update is called once per frame
    void Update()
    {
		if (!action) {
        if ((Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1)) && actionCount > 0 && readyToAction && actionsList[0]!= "")
        {
			action = true;
            output.text = "You used " + actionsList[0] + ".";
            readyToAction = false;
            //включить скрипт взаимодействия с 1ым обектом
            string tmp = colliderList[0].GetComponent<ScriptName>().scriptName;
            if (tmp == "")
            {
                tmp = "ScriptName";
            }
            (colliderList[0].GetComponent(tmp) as MonoBehaviour).enabled = true;
			//action = false;
        }
        if ((Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2)) && actionCount > 0 && readyToAction && actionsList[1] != "")
        {
			action = true;
            output.text = "You used " + actionsList[1] + ".";
            readyToAction = false;
            //включить скрипт взаимодействия со 2ым обектом
            string tmp = colliderList[1].GetComponent<ScriptName>().scriptName;
            if (tmp == "")
            {
                tmp = "ScriptName";
            }
            (colliderList[1].GetComponent(tmp) as MonoBehaviour).enabled = true;
			//action = false;
        }
        if ((Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Keypad3)) && actionCount > 0 && readyToAction && actionsList[2] != "")
        {
			action = true;
            output.text = "You used " + actionsList[2] + ".";
            readyToAction = false;
            //включить скрипт взаимодействия с 3им обектом
            string tmp = colliderList[2].GetComponent<ScriptName>().scriptName;
            if (tmp == "")
            {
                tmp = "ScriptName";
            }
            (colliderList[2].GetComponent(tmp) as MonoBehaviour).enabled = true;
			//action = false;
        }

        if (actionCount < 0 || actionCount > 3)
        {
            actionCount = 0;
        }

        if (doorDown && (Input.GetAxis("Vertical")==-1))
        {
            colDown.GetComponent<Doors>().Transport();
        }
        if (doorUp && (Input.GetAxis("Vertical") == 1))
        {
            colUp.GetComponent<Doors>().Transport();
        }

    }
		else action = false;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Action")
        {
            /*switch (actionCount)
            {
                case (0):
                    {
                        readyToAction = true;
                        actionName = other.name;
                        output.text = "Press 1 to interact with " + actionName + ".";
                        actionsList[actionCount] = actionName;
                        colliderList[actionCount] = other;
                        actionCount++;
                        break;
                    }
                case (1):
                    {
                        if (actionsList[0] != other.name)
                        {
                            readyToAction = true;
                            actionName = other.name;
                            output.text += "\nPress 2 to interact with " + actionName + ".";
                            actionsList[actionCount] = actionName;
                            colliderList[actionCount] = other;
                            actionCount++;
                        }

                        break;
                    }
                case (2):
                    {
                        if (actionsList[0] != other.name && actionsList[1] != other.name)
                        {
                            readyToAction = true;
                            actionName = other.name;
                            output.text += "\nPress 3 to interact with " + actionName + ".";
                            actionsList[actionCount] = actionName;
                            colliderList[actionCount] = other;
                            actionCount++;
                        }
                        break;
                    }
                default:
                    { break; }
            }*/

            //string tmp = "";
            readyToAction = true;
            actionName = other.name;
            actionsList[actionCount] = actionName;
            colliderList[actionCount] = other;
            //for (int i = 0; i < 3; i++)
            //{
            //    if (actionsList[i]!="")
            //    {
            //        tmp += "Press " + (i + 1) + " to interact with " + actionsList[i] + ".\n";
            //    }
            //}
            actionCount++;
        }
        if (other.tag == "DoorUp")
        {
            /*if (actionCount != 0)
            {
                output.text += "Hold UP to use the door.";
            }
            else
            {
                output.text = "Hold UP to use the door.";
            }*/
            doorUp = true;
            colUp = other;
        }
        if (other.tag == "DoorDown")
        {
            /*if (actionCount != 0)
            {
                output.text += "Hold DOWN to use the door.";
            }
            else
            {
                output.text = "Hold DOWN to use the door.";
            }*/
            doorDown = true;
            colDown = other;
        }
        output.text = TextOutput();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Action")
        {
            if (actionCount < 1)
            {
                readyToAction = false;
            }
            //output.text = ""; //не надо удалять все!!
            for (int i = 0; i < 3; i++)
            {
                if (actionsList[i] == other.name)
                {
                    actionsList[i] = "";
                    colliderList[i] = null;
                    continue;                   
                }
            }

            actionCount--;
            output.text = TextOutput(); 
        }
        if (other.tag == "DoorDown")
        {
            doorDown = false;
            colDown = null;
        }
        if (other.tag == "DoorUp")
        {
            doorUp = false;
            colUp = null;
        }
        output.text = TextOutput();
    }

    string TextOutput()
    {
        string tmp = "";
        for (int i = 0; i < 3; i++)
        {
            if (actionsList[i] != "")
            {
                tmp += "Press " + (i + 1) + " to interact with " + actionsList[i] + ".\n";
            }
        }
        if (doorDown) tmp += "Hold DOWN to use the door.\n";
        if (doorUp) tmp += "Hold UP to use the door.\n";

        return tmp;
    }
}
