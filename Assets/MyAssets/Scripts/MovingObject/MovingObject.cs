using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void StopScrolling()
    {
        rb2D.velocity = Vector2.zero;
    }

}
