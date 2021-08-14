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

    public void StartScrolling()
    {
        rb2D.velocity = new Vector2(GameMaster.instance.movingSpeed, 0);
    }
}
