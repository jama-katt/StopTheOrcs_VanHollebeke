using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorTextScript : MonoBehaviour
{
    public float errorTimer = 3f;
    float secondsToPass = 0f;
    public Text errorText;
    public void Error(string text)
    {
        secondsToPass = errorTimer;
        errorText.text = text;
    }

    private void Update()
    {
        if (secondsToPass > 0)
        {
            secondsToPass -= Time.deltaTime;
        }
        else if (secondsToPass < 0 )
        {
            errorText.text = "";
            secondsToPass = 0f;
        }
    }
}
