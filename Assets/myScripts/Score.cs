using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{

    public Text scoreText;
    public Text failText;//

    public static int scoreValue = 0;
    public int endScore = 100;

    public static int failValue = 0;//
    public int failScore = 40;//

    Text score;
    Text fail;//

    void Start()
    {
        score = GetComponent<Text>();
        scoreText.text = "";

        fail = GetComponent<Text>();
        failText.text = "";

        if (scoreValue >= endScore) 
        {
            EndGame();
        }

        if (failValue >= failScore)
        {
            GameOver();
        }
    }

    void Update()
    {
        scoreText.text = "Score: " + scoreValue.ToString();
    }

    void EndGame()
    {
        SceneManager.LoadScene("EndingScene");
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

}