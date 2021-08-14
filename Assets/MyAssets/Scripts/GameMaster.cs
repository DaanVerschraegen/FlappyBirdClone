using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    public float movingSpeed = -1.5f;

    private int score = 0;
    [SerializeField] private TextMeshProUGUI txtScore; 
    
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

    //Add 1 score point per column flown trough
    public void AddScore()
    {
        score++;
        txtScore.text = score.ToString();
    }
}
