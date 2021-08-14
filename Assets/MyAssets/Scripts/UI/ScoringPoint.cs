using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            GameMaster.instance.AddScore();
        }
    }
}
