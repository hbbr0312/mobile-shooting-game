using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMaster : MonoBehaviour
{
    public int points;
    public int cherries;
    public bool hell;

    public Text pointsText;
    public Text cherriesText;
    public Text gameover;
    // Start is called before the first frame update
    void Start()
    {
        cherries = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("text update!");
        pointsText.text = ("Points: " + points);
        cherriesText.text = ("Cherries: " +cherries);
        //gameover
        if (hell || cherries <= 0) gameover.text = "GAME OVER !!!!";
        else gameover.text = "";
    }
}
