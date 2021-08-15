using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    public float movingSpeed = -1.5f;
    public bool isGameOver = false;

    private int score = 0;
    [SerializeField] private TextMeshProUGUI txtScore;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        InterstitialAds.instance.LoadAd();
        PauseGame();
    }

    //Show ads then restart game
    public void GameOver(AudioSource audioSrc)
    {
        isGameOver = true;
        InterstitialAds.instance.ShowAd();
        StartCoroutine(RestartLevelAfterAudio(audioSrc));
    }

    //Add 1 score point per column flown trough
    public void AddScore()
    {
        score++;
        txtScore.text = score.ToString();
    }

    private IEnumerator RestartLevelAfterAudio(AudioSource audioSrc)
    {
        float clipDuration = audioSrc.clip.length;
        yield return new WaitForSeconds(clipDuration);
        RestartLevel();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1f;
    }
}
