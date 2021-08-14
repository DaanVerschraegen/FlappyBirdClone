using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    //Show add then restart game
    public void GameOver()
    {
        //Show add
        //After add reload scene:
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
