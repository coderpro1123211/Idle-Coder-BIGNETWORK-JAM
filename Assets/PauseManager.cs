using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    bool isPaused;
    public GameObject pausePanel;
    public GameObject p;
    public GameObject mainPanel;


    private void Start()
    {
        pausePanel.SetActive(false);
        p.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPaused) Unpause();
        else Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
        pausePanel.SetActive(true);
        p.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        isPaused = false;
        pausePanel.SetActive(false);
        p.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void GotoMain()
    {
        SceneManager.LoadScene(0);
    }
}
