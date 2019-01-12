using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;
    bool pauseclick = false;
    private bool paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
    }
    void Update()
    {
        if (pauseclick)
        {
            paused = !paused;
            pauseclick = false;
        }
        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void Resume()
    {
        paused = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
    public void MainMenu()
    {
        //Application.LoadLevel(1);
    }
    public void pause()
    {
        pauseclick = true;
        PauseUI.SetActive(true);
    }
}
