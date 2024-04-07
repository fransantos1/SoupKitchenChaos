using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenuGameObject;

    public Button resumeButton;
    public Button optionsButton;
    public Button quitButton;
    public GameObject soupPanel;
    public GameObject burgerPanel;
    public GameObject codPanel;
    public GameObject optionsMenu;
    public Points points;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        /*
        soupPanel.SetActive(false);
        burgerPanel.SetActive(false);
        codPanel.SetActive(false);
        */
        pauseMenuGameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenuGameObject.SetActive(false);

        /*
        soupPanel.SetActive(true);
        burgerPanel.SetActive(true);
        codPanel.SetActive(true);
        */
    }

    public void OpenOptionsMenu()
    {
        resumeButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        optionsMenu.gameObject.SetActive(true);
    }

    public void ReturnToPauseMenu()
    {
        resumeButton.gameObject.SetActive(true);
        optionsButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        optionsMenu.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        points.SavePoints();
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
