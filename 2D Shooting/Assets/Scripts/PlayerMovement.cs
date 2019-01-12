using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
    public Joystick joystick;
    //coin
    private gameMaster gm;

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

	public void OnLanding ()
	{
		animator.SetBool("IsJumping",false);
	}

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
        Debug.Log("enter the ontrigger ");
        Debug.Log("point " + gm.points);
        if (col.gameObject.tag == "coin")
        {
            Debug.Log("touch ! " + gm.points);
            gm.points += 1;
            Destroy(col.gameObject);
            
        }
        if(col.gameObject.tag == "Cherry")
        {
            Destroy(col.gameObject);
            gm.cherries += 1;
        }
        if(col.gameObject.tag == "Enemy")
        {
            gm.cherries -= 1;
            attacked = true;
        }
        if(col.gameObject.tag == "Hell")
        {
            gm.hell = true;
            Destroy(col.gameObject);
        }
    }
}
