using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 200f;

    private bool isDead;
    private bool jump;
    private Rigidbody2D rb2D;

    private void Awake()
    {
        Initialise();
    }

    private void Initialise()
    {
        rb2D = GetComponent<Rigidbody2D>();
        isDead = false;
        jump = false;
    }

    private void Update()
    {
        if (!isDead)
        {
            if(Input.GetMouseButtonDown(0))
            {
                jump = true;
            }
        }   
    }

    private void FixedUpdate()
    {
        if(jump)
        {
            Jump();
            jump = false;
        }
    }

    private void Jump()
    {
        rb2D.velocity = Vector2.zero;
        rb2D.AddForce(new Vector2(0, jumpForce));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //Game ends when Flappy hits either a pipe or the ground
        if(col.gameObject.tag == "Pipe" || col.gameObject.tag == "Ground")
        {
            isDead = true;
            GameMaster.instance.GameOver();
        }
    }
}
