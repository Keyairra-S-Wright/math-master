using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Penalty : MonoBehaviour
{

    public Text failText;//

    public static int failValue = 0;//
    public int failScore = 4;//

    Text fail;//

    void Start()
    {
        fail = GetComponent<Text>();
        failText.text = "";


        //We are never hitting this debug.log statement in the console
        if (failValue >= failScore)
        {
            Debug.Log("GameOver");
            GameOver();
        }

    }

    void Update()
    {
        failText.text = "Penalty: " + failValue.ToString();
    }


    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

}