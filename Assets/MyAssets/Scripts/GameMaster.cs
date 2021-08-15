using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(InterstitialAds))]
public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    public float movingSpeed = -1.5f;
    public bool isGameOver = false;

    private int score = 0;
    [SerializeField] private TextMeshProUGUI txtScore;
    private InterstitialAds adsManager;
    
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Initialise();
            instance = this;
        }
    }

    private void Initialise()
    {
        adsManager = GetComponent<InterstitialAds>();
    }

    private void Start()
    {
        adsManager.LoadAd();
    }

    //Show ads then restart game
    public void GameOver()
    {
        isGameOver = true;
        adsManager.ShowAd();
    }

    //Add 1 score point per column flown trough
    public void AddScore()
    {
        score++;
        txtScore.text = score.ToString();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
