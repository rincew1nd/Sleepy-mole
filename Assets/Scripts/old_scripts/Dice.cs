using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour
{

    public int CurDice;

    public GUIText DiceGUI;
    // Use this for initialization
    void Start()
    {
        DiceGUI = this.guiText;
    }

    void Update()
    {
        if (Input.GetAxis("Roll") > 0)
        {
            Roll();
        }
    }

    public void Roll()
    {
        CurDice = Random.Range(1, 21);
        Refresh();
    }

    public void Refresh()
    {
        if (CurDice == 0)
        {
            DiceGUI.text = "";
        }
        else
        {
            DiceGUI.text = CurDice.ToString();
        }
    }

    public void Clear()
    {
        CurDice = 0;
        Refresh();
    }

}
