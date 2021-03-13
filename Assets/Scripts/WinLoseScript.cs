using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLoseScript : MonoBehaviour
{
    public AudioSource mainMusic;
    public AudioSource winMusic;

    public Image pauseMenu;
    public Image escapeThing;
    public Button resumeButton;
    public KeyCode quitKey;
    public Text winLoseText;
    bool gameOver = false;
    bool paused = false;

    public void Win()
    {
        if (!gameOver)
        {
            mainMusic.mute = true;
            winMusic.Play();
            Time.timeScale = 0f;
            escapeThing.gameObject.SetActive(false);
            pauseMenu.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);
            winLoseText.text = "You Win!";
            gameOver = true;
        }
    }

    public void Lose()
    {
        if (!gameOver)
        {
            Time.timeScale = 0f;
            escapeThing.gameObject.SetActive(false);
            pauseMenu.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);
            winLoseText.text = "You Lose";
            gameOver = true;
        }
    }

    public void Pause()
    {
        if (paused)
        {
            Time.timeScale = 1f;
            escapeThing.gameObject.SetActive(true);
            pauseMenu.gameObject.SetActive(false);
            paused = false;
        }
        else
        {
            Time.timeScale = 0f;
            escapeThing.gameObject.SetActive(false);
            pauseMenu.gameObject.SetActive(true);
            paused = true;
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        if (!gameOver)
        {
            if (Input.GetKeyDown(quitKey))
            {
                Pause();
            }
        }
    }
}
