using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolSelector : MonoBehaviour
{
    public Text currencyText;
    public Text scoreText;
    public WinLoseScript winLoseScript;


    public int toolSelected = 0;
    public int currency = 0;
    public int score = 0;

    private void Update()
    {
        currencyText.text = "" + currency;
        scoreText.text = "" + score;
        if (score <= 0)
        {
            score = 0;
            winLoseScript.Lose();
        }
    }
}
