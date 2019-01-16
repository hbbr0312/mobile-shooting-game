using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuclick : MonoBehaviour
{
    public GameObject gameclearUI;
    public GameObject PauseUI;
    public GameObject MainUI;
    public GameObject gameoverUI;
    public Text gems;
    public Text hearts;
    public Text monsters;

    private gameMaster gm; //life, gems, gameover, game clear 관리
    
    bool pauseclick = false;
    private bool paused = false;

    void Start()
    {
        gm = GameObject.FindWithTag("GameMaster").GetComponent<gameMaster>();
        PauseUI.SetActive(false);
    }
    void Update()
    {
        Debug.Log("updating");
        //clear
        if (gm.clear)
        {
            gameclearUI.SetActive(true);
            MainUI.SetActive(false);
            gems.text = ("X " + gm.gems);
            hearts.text = ("X " +gm.cherries);
            monsters.text = ("X "+gm.monster);
        }
        //game over
        else if (gm.isgameover)
        {
            gameoverUI.SetActive(true);
            MainUI.SetActive(false);
        }

        //paused
        else
        {
            if (pauseclick)
            {
                paused = !paused;
                pauseclick = false;
            }
            if (paused)
            {
                PauseUI.SetActive(true);
                MainUI.SetActive(false);
                Time.timeScale = 0;
            }
            if (!paused)
            {
                PauseUI.SetActive(false);
                MainUI.SetActive(true);
                Time.timeScale = 1;
            }
        }
        
        
    }
    public void Resume()
    {
        paused = false;
    }
    public void tutorial()
    {
        gameclearUI.SetActive(false);
        SceneManager.LoadScene("Tutorial");
    }
    public void stage1()
    {
        gameclearUI.SetActive(false);
        SceneManager.LoadScene("Stage1");
    }
    public void stage2()
    {
        gameclearUI.SetActive(false);
        SceneManager.LoadScene("Stage2");
    }
    public void MainMenu()
    {
        gameclearUI.SetActive(false);
        SceneManager.LoadScene("Mainmenu");
    }
    public void pause()
    {
        pauseclick = true;
        PauseUI.SetActive(true);
    }
    
}
