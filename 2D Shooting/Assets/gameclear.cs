using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameclear : MonoBehaviour
{
    bool gameClear;
    private gameMaster gm; //life, gems, gameover, game clear 관리
    public GameObject gameclearUI;
    public GameObject mainCanvas;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameMaster").GetComponent<gameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.clear)
        {
            Debug.Log("clear !!");
            gameclearUI.SetActive(true);
            mainCanvas.SetActive(false);
        }
    }
    public void nextStage()
    {
        //SceneManager.LoadScene("stage2");
    }
    
}