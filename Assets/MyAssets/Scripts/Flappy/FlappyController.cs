using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class FlappyController : MonoBehaviour
{
    [Header("Flappy Settings")]
    [SerializeField] private float jumpForce = 200f;
    private bool isDead;
    private bool jump;
    private Rigidbody2D rb2D;

    [Header("Audio Settings")]
    [SerializeField] private AudioClip audioFly;
    [SerializeField] private AudioClip audioThump;
    private AudioSource audioSrc;

    private void Awake()
    {
        Initialise();
    }

    private void Initialise()
    {
        rb2D = GetComponent<Rigidbody2D>();
        audioSrc = GetComponent<AudioSource>();
        isDead = false;
        jump = false;
    }

    private void Update()
    {
        if (!isDead)
        {
            if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                jump = true;
            }

#if UNITY_EDITOR
            if(Input.GetButtonDown("LeftMouseClick"))
            {
                jump = true;
            }
#endif
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
        PlayAudio(audioFly);
        rb2D.AddForce(new Vector2(0, jumpForce));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //Game ends when Flappy hits either a pipe or the ground
        if(!isDead && (col.gameObject.tag == "Pipe" || col.gameObject.tag == "Ground"))
        {
            PlayAudio(audioThump);
            isDead = true;
            GameMaster.instance.GameOver(audioSrc);
        }
    }

    private void PlayAudio(AudioClip audioToPlay)
    {
        audioSrc.clip = audioToPlay;
        audioSrc.Play();
    }
}
