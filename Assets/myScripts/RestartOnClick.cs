using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnClick : MonoBehaviour
{

    void Restart ()
    {
        Score.scoreValue = 0;
        Penalty.failValue = 0;
        SceneManager.LoadScene("Main");
    }
}
