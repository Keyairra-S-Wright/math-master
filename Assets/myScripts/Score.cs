using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text scoreText;

    public static int scoreValue = 0;
    Text score;

    void Start()
    {
        score = GetComponent<Text>();
        scoreText.text = "";

        Debug.Log(score);
    }

    void Update()
    {
        scoreText.text = "Score: " + scoreValue.ToString();
    }

}