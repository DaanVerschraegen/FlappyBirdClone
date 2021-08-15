using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        GameMaster.instance.UnPauseGame();
        gameObject.SetActive(false);
    }
}
