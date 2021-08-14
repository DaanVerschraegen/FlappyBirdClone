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
        InitialiseFlappy();
    }

    private void InitialiseFlappy()
    {
        rb2D = GetComponent<Rigidbody2D>();
        ResetFlappyVariables();
    }

    public void ResetFlappyVariables()
    {
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
        if(col.gameObject.tag == "Pipe" || col.gameObject.tag == "Ground")
        {
            isDead = true;
        }
    }
}
