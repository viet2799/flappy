using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public Bird bird;


    private void Awake()
    {
        Pause();
    }

    public void Play()
    {
        Debug.Log("btn");
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        bird.enabled = true;

        Collum[] collums = FindObjectsOfType<Collum>();

        for (int i = 0; i < collums.Length; i++)
        {
            Destroy(collums[i].gameObject);
        }
    }
    public void GameOver()
    {
        Debug.Log("gameOver");
        playButton.SetActive(true);
        gameOver.SetActive(true);
        Pause();

    }
    public void Pause()
    {
        Time.timeScale = 0f;
        bird.enabled = false;
    }

    public void UpScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
