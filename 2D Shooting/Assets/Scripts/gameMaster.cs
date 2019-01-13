using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMaster : MonoBehaviour
{
    public int gems;
    public int cherries; //목숨을 의미
    public bool hell; //낭떠러지에 닿았는지
    public bool bossdie;
    public Text pointsText;
    public Text gameover;
    public Text gameclear;

    // Start is called before the first frame update
    void Start()
    {
        cherries = 5;
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = ("X " + gems); //gems number update in mainCanvas
        //Game Over => TODO : game over scene으로 전환
        if (cherries <= 0 || hell)
        {
            Debug.Log("gameover");
            gameover.text = "GAME OVER !!!!";
        }
        else gameover.text = "";

        //Game Clear => TODO : game clear scene(다음스테이지)으로 전환
        if (bossdie)
        {
            Debug.Log("game clear");
            gameclear.text = "GAME CLEAR !!!!";
        }
        else gameclear.text = "";
    }
}
