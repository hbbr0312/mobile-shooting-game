using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller; //character 관리
	public Animator animator; //animation 관리
    public Joystick joystick;
   
    private gameMaster gm; //life, gems, gameover, game clear 관리
    public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
    bool attacked = false;


    void Start()
    {
        gm = GameObject.FindWithTag("GameMaster").GetComponent<gameMaster>();
    }

    // Update is called once per frame
    void Update () {

        if (joystick.Horizontal >= .2f)
        {
            horizontalMove = runSpeed;
        }
        else if (joystick.Horizontal <= -.2f)
        {
            horizontalMove = -runSpeed;
        }
        else
        {
            horizontalMove = 0f;
        }
        if (joystick.Vertical >= .5f)
        {
            jump = true;
            //Debug.Log("jump");
        }
        else if (joystick.Vertical <= -.5f)
        {
            crouch = true;
            //Debug.Log("crouch");
        }
        else
        {
            crouch = false;
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        animator.SetBool("Attacked", attacked);
    }
    //착지시 점프 false로
	public void OnLanding ()
	{
		animator.SetBool("IsJumping",false);
	}
    //앉기
	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
        attacked = false;
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //보석에 닿았을때
        if (col.gameObject.tag == "Gem")
        {
            gm.gems += 1;
            Destroy(col.gameObject);
            FindObjectOfType<SoundManagerScript>().Play("gotitem");
        }
        //체리에 닿았을때 = 목숨+1
        if(col.gameObject.tag == "Cherry")
        {
            Destroy(col.gameObject);
            if(gm.cherries<5) gm.cherries += 1;
        }
        //몬스터에게 닿았을때 = 목숨-1
        if(col.gameObject.tag == "Enemy")
        {
            if (gm.cherries >0) gm.cherries -= 1;
            attacked = true;

        }
        //낭떠러지에 떨어질때
        if(col.gameObject.tag == "Hell")
        {
            gm.hell = true;
            Destroy(col.gameObject);
        }


        /****튜토리얼****/
        //when touching tuto_startline
        if (col.gameObject.tag == "tuto_start")
        {
            gm.tutoindex = 0;
            Destroy(col.gameObject);
        }

        //when touching a cute frog
        if (col.gameObject.tag == "tuto_frog")
        {
            gm.tutoindex = 1;
            gm.cherries -= 1;
            attacked = true;
        }

        //when touchig a gem
        if (col.gameObject.tag == "tuto_gem")
        {
            gm.tutoindex = 3;
            gm.gems += 1;
            Destroy(col.gameObject);
            FindObjectOfType<SoundManagerScript>().Play("gotitem");
        }

        //when touching tuto_finishingline
        if (col.gameObject.tag == "tuto_finish")
        {
            gm.tutoindex = 4;
            Destroy(col.gameObject);
        }
    }
}
