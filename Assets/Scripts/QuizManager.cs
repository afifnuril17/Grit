using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public QuizUI quizUI;
    public QuestionData[] questions;
    private static List<QuestionData> unansweredQuestion;
    private QuestionData currentQuestion;
    public PlayerController player;
    public Canvas questionCanvas;
    public int questionIndex;
    public QuizController quizController;
    int count = 0;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        if(unansweredQuestion == null || unansweredQuestion.Count == 0)
        {
            unansweredQuestion = questions.ToList<QuestionData>();
        }

        if(player.GetCurrentLevel() == 7)
        {
            questionIndex = 0;
            SetCurrentQuestion();
        }
        else if(player.GetCurrentLevel() == 8)
        {
            questionIndex = 3;
            SetCurrentQuestion();
        }
        else if(player.GetCurrentLevel() == 9)
        {
            questionIndex = 6;
            SetCurrentQuestion();
        }
        else if(player.GetCurrentLevel() == 10)
        {
            questionIndex = 9;
            SetCurrentQuestion();
        }
        else if(player.GetCurrentLevel() == 6)
        {
            questionIndex = 12;
            SetCurrentQuestion();
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetCurrentQuestion()
    {
        currentQuestion = unansweredQuestion[questionIndex];

        quizUI.SetQuestion(currentQuestion);

        // unansweredQuestion.RemoveAt(questionIndex);
        questionIndex++;
        // count++;
    }

    public void AnswerButtonClicked(bool isCorrect)
    {
            
        if(count < 2)
        {
            if(count == 0)
            {
                if(isCorrect)
                {
                    player.SetFirstAbstract(1);
                }
                else
                {
                    player.SetFirstAbstract(0);
                }
            }
            else if(count == 1)
            {
                if(isCorrect)
                {
                    player.SetSecondAbstract(1);
                }
                else
                {
                    player.SetSecondAbstract(0);
                }
            }
            count++;
            SetCurrentQuestion();
        }
        else if(count == 2)
        {
            if(isCorrect)
            {
                player.SetThirdAbstract(1);
            }
            else
            {
                player.SetThirdAbstract(0);
            }
            count++;

            player.SetPasswordForKey(1);
            questionCanvas.enabled = false;
            player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            player.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
            quizController.gameObject.SetActive(false);
            player.PlaySound(audioClip);
        }
        else
        {
            return;
                // Debug.Log(player.GetPasswordForKey());
        }
            
    }
       
        
    

    
}

