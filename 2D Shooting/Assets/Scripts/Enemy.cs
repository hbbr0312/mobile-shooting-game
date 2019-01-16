using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health = 100;
    public bool isBoss;
    public bool bossofboss;

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
        gm.monster += 1;
		Instantiate(deathEffect, transform.position, Quaternion.identity);
        if (isBoss)
        {
            if (bossofboss) gm.clear=true;
            if (gm.tutorialtextOn) gm.tutoindex = 4;
        }
        if(gameObject.tag == "tuto_frog")
        {
            gm.tutoindex = 2;
            FindObjectOfType<SoundManagerScript>().Stop("frog");
        }

        Debug.Log("is boss ? = " + isBoss);
        Destroy(gameObject);
	}
}
