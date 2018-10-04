using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{

    public Text scoreText;

    public static int scoreValue = 0;
    public int endScore = 100;
    Text score;

    void Start()
    {
        score = GetComponent<Text>();
        scoreText.text = "";
        Debug.Log(score);
        if (scoreValue >= endScore) 
        {
            EndGame();
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

}