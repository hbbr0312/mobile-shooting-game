using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health = 100;
    public bool isBoss;

	public GameObject deathEffect;
    private gameMaster gm;

    void Start()
    {
        gm = GameObject.FindWithTag("GameMaster").GetComponent<gameMaster>();
    }

    public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die ()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
        if (isBoss)
        {
            if (gm.tutorialtextOn) gm.tutoindex = 5;
            gm.bossdie = true;
        }
        if(gameObject.tag == "tuto_frog")
        {
            gm.tutoindex = 2;
        }

        Debug.Log("is boss ? = " + isBoss);
        Destroy(gameObject);
	}

}
