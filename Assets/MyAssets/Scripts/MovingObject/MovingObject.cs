using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingObject : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private void Awake()
    {
        Initialise();
    }

    private void Initialise()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartScrolling();
    }

    private void Update()
    {
        if(GameMaster.instance.isGameOver)
        {
            StopScrolling();
        }
    }

    private void StartScrolling()
    {
        rb2D.velocity = new Vector2(GameMaster.instance.movingSpeed, 0);
    }

    private void StopScrolling()
    {
        rb2D.velocity = Vector2.zero;
    }
}
