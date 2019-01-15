using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    bool gameOver;
    private gameMaster gm; //life, gems, gameover, game clear 관리
    public GameObject gameoverUI;
    public GameObject mainCanvas;

    void Start()
    {
        gm = GameObject.FindWithTag("GameMaster").GetComponent<gameMaster>();
    }
    void Update()
    {
        gameoverUI.SetActive(gm.isgameover);
        if (gm.isgameover) mainCanvas.SetActive(false);
    }
}
