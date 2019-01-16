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
    public int monster = 0;

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

        //Game Clear
        if (clear)
        {
            Debug.Log("game clear");
            FindObjectOfType<SoundManagerScript>().Play("successful");
        }

        //Game Over
        else if (cherries <= 0 || hell)
        {
            FindObjectOfType<SoundManagerScript>().Stop("theme");
            if(tutorialtextOn)FindObjectOfType<SoundManagerScript>().Stop("frog");
            Debug.Log("gameover");
            isgameover = true;
            FindObjectOfType<SoundManagerScript>().Play("gameover");
        }
        
        //tutorial
        if (tutorialtextOn)
        {
            switch (tutoindex)
            {
                case 0: //처음시작하자마자//
                    tutorial.text = "Oh! There  is  a  cute  frog!" + "\n" + "Approach  a  frog.";
                    Debug.Log("touch the guide line");
                    break;
                case 1: //개구리에게 닿았을때//
                    tutorial.text = "If  you  touch  a  monster,  you  lose  health."+ "\n" +"Kill  him  by  pressing  red  button!";
                    break;
                case 2: //개구리 죽였을때//
                    tutorial.text = "Good  job!" + "\n" + "Now  collect  gems.";
                    break;
                case 3: //보석먹을때//
                    tutorial.text = "Well  done." + "\n" + "You  have  to  kill  the  Boss  Monster  to  clear  game.";
                    break;
                case 4: //Boss 죽였을때
                    tutorial.text = "Perfect !!" + "\n" + "Pick  up  the  cherry  to  recover  health !";
                    break;
                default:
                    tutorial.text = "";
                    break;
            }
           
        }

    
    }
}
