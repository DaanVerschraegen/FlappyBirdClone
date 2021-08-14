using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundLength;

    private void Awake()
    {
        Initialise();
    }

    private void Initialise()
    {
        groundCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        groundLength = groundCollider.size.x;
    }

    private void Update()
    {
        if(transform.position.x < -groundLength)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
