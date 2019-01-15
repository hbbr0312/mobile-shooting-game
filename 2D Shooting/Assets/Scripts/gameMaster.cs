using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMaster : MonoBehaviour
{
    public int gems;
    public int cherries; //목숨을 의미
    public bool hell; //낭떠러지에 닿았는지
    public bool clear;
    public bool tutorialtextOn;
    public int tutoindex;
    public bool isgameover=false;

    public Text pointsText;
    public Text tutorial;

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
            FindObjectOfType<SoundManagerScript>().Stop("theme");
            FindObjectOfType<SoundManagerScript>().Stop("frog");
            Debug.Log("gameover");
            isgameover = true;
            FindObjectOfType<SoundManagerScript>().Play("gameover");
        }
        
        //Game Clear => TODO : game clear scene(다음스테이지)으로 전환
        if (clear)
        {
            Debug.Log("game clear");
            FindObjectOfType<SoundManagerScript>().Play("successful");
        }
       

        //tutorial
        if (tutorialtextOn)
        {
            switch (tutoindex)
            {
                case 0: //처음시작하자마자//
                    tutorial.text = "Oh! There is a cute frog!" + "\n" + "Approach a frog.";
                    Debug.Log("touch the guide line");
                    break;
                case 1: //개구리에게 닿았을때//
                    tutorial.text = "If you touch a monster, you lose health."+ "\n" +"Kill him by pressing red button!";
                    break;
                case 2: //개구리 죽였을때//
                    tutorial.text = "Good job!" + "\n" + "Pick up the cherry to recover health.";
                    break;
                case 3: //보석먹을때//
                    tutorial.text = "Well done." + "\n" + "When you see gems, pick up them!";
                    break;
                case 4: //마지막 가이드라인 닿았을때
                    tutorial.text = "You have to kill the Boss Monster to clear game.";
                    break;
                case 5: //Boss 죽였을때
                    tutorial.text = "Perfect !!" + "\n" + "You cleared the tutorial !";
                    break;
                default:
                    tutorial.text = "";
                    break;
            }
           
        }

    
    }
}
