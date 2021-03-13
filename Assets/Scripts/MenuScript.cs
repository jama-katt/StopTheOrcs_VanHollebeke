using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject instructionMenu;
    bool instruct = false;
    public void Instruct()
    {
        if (instruct)
        {
            instructionMenu.SetActive(false);
            instruct = false;
        }
        else
        {
            instructionMenu.SetActive(true);
            instruct = true;
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
