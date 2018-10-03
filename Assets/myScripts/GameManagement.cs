using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class GameManagement : MonoBehaviour {

    public Question[] questions; //below will allow us to pick random questions w/o repeating
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private Text factText;

    private void Start()
    {
        if(unansweredQuestions == null || unansweredQuestions.Count == 0){
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();

    }

    void SetCurrentQuestion(){ //below will take the element from the random index
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;
        unansweredQuestions.RemoveAt(randomQuestionIndex); //this removes questions from the list once they are answered
    }
}
