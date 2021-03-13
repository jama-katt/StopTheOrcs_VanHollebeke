using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public int toolNumber;
    public Button button;
    public ToolSelector toolSelector;
    bool selected = false;

    public void Select()
    {
        if (selected)
        {
            Deselect();
            toolSelector.toolSelected = 0;
        }
        else
        {
            button.image.color = Color.gray;
            selected = true;
            toolSelector.toolSelected = toolNumber;
        }
    }

    public void Deselect()
    {
        button.image.color = Color.white;
        selected = false;
    }
}
