using UnityEngine;
using System.Collections;

public class Cabinets : MonoBehaviour
{

    public GUIText Output;
    public Dice d;

    // Use this for initialization
    void Start()
    {
        d = FindObjectOfType<Dice>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        string tmp = "";
        if (this.enabled)
        {
            if (d.CurDice > 0)
            {
                //Debug.Log("nice");
                if (d.CurDice == 1)
                {
                    tmp 
                    //Output.text 
                    = "Cabinets are broken...";
                }
                else if (d.CurDice >= 2 && d.CurDice <= 7)
                {
                     tmp 
                    //Output.text 
                    = "Cabinets are closed...";
                }
                else if (d.CurDice >= 8 && d.CurDice <= 13)
                {
                     tmp 
                    //Output.text 
                    = "Cabinets are empty...";
                }
                else if (d.CurDice >= 14 && d.CurDice <= 19)
                {
                     tmp 
                    //Output.text 
                    = "Cabinets have nothing useful...";
                }
                else if (d.CurDice == 20)
                {
                     tmp 
                    //Output.text 
                    = "Cabinets are FULL with stuff...";
                }
            }
            else
            {
                //Debug.Log("not nice");
                 tmp 
                    //Output.text 
                    = "Cabinets are empty...";
                this.enabled = false;
            }
            this.enabled = false;
            d.Clear();
            Output.text = tmp;
        }
    }
}
