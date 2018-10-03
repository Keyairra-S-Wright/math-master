using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Similar to DataController; minute 3 in tutorial 2
//Similar to GameController; minute 5 tutorial 6 to set up player score
//Similar to GameController; minute 2 tutorial 7 to add to player schore

public class GameManagement : MonoBehaviour {

    ////the public string text below may not be needed - video 2, minute 2
    //public string questionText;

    public Question[] questions; //below will allow us to pick random questions w/o repeating
    private static List<Question> unansweredQuestions;


    //Use this for score
    //private int playerScore;
    //[SerializeField]
    //private Text score;

    private Question currentQuestion;

    //[SerializeField]
    //private Text scoreText;

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
        //DontDestroyOnLoad(gameObject);
        //SceneManager.LoadScene("MenuScreen");

        //playerScore = 0;

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

        //Player score may go here based on falseAnwerText.text or trueAnswerText.text == "You're Correct!"
     }

    IEnumerator TransitionToNextQuestion(){
        unansweredQuestions.Remove(currentQuestion); //this removes questions from the list once they are answered
        yield return new WaitForSeconds(timeBetweenQuestions);
        Score.scoreValue += 10;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UserSelectTrue(){
        animator.SetTrigger("True");
        if (currentQuestion.isTrue)
        {
            //use the score here
            Debug.Log("CORRECT!");
        }
        else 
        {
            Debug.Log("WRONG!");
        }

        StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectFalse()
    {
        animator.SetTrigger("False");
        if (!currentQuestion.isTrue) //is not true
        {
            //user score here
            Debug.Log("CORRECT!");
        }

        else
        {
            Debug.Log("WRONG!");
        }
        StartCoroutine(TransitionToNextQuestion());
    }
}
