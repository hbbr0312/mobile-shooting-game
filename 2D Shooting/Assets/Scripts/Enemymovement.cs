using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    public Transform[] target;
    public float speed;
    private int current;
    private bool m_FacingRight = false;//왼쪽을 보는걸로 시작


    // Update is called once per frame
    void Update()
    {
        if (transform.position != target[current].position)
        {
            Vector2 pos = Vector2.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(pos);
        }
        else current = (current + 1) % target.Length;
    }

    public void Move(float speed)
    {
        if (speed > 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (speed < 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
