﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour {

    public Question[] questions; //below will allow us to pick random questions w/o repeating
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private Text factText;

    [SerializeField]
    private Text trueAnswerText;

    [SerializeField]
    private Text falseAnswerText;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float timeBetweenQuestions = 2f;

    private void Start()
    {

        if (unansweredQuestions == null || unansweredQuestions.Count == 0){
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();

    }

    void SetCurrentQuestion(){ //below will take the element from the random index
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;

        if (currentQuestion.isTrue)
        {
            trueAnswerText.text = "You're Correct!";
            falseAnswerText.text = "Wrong";
        } else
        {
            trueAnswerText.text = "Wrong";
            falseAnswerText.text = "You're Correct!";
        }
     }

    IEnumerator TransitionToNextQuestion(){
        unansweredQuestions.Remove(currentQuestion); //this removes questions from the list once they are answered
        yield return new WaitForSeconds(timeBetweenQuestions);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void UserSelectTrue(){
        animator.SetTrigger("True");
        if (currentQuestion.isTrue)
        {
            Score.scoreValue += 10;
            Debug.Log("CORRECT!");
        }
        else 
        {
            Penalty.failValue += 1;
            Debug.Log("WRONG!");
        }

        StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectFalse()
    {
        animator.SetTrigger("False");
        if (!currentQuestion.isTrue) //is not true
        {

            Score.scoreValue += 10;
            Debug.Log("CORRECT!");
        }

        else
        {
            Penalty.failValue += 1;
            Debug.Log("WRONG!");
        }
        StartCoroutine(TransitionToNextQuestion());
    }

}
