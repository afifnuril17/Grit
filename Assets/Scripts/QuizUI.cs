using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    [SerializeField]private QuizManager quizManager;
    [SerializeField]private Text questionTextUI;
    [SerializeField]private Image questionImageUI;
    [SerializeField]private Image questionImageUISecond;
    [SerializeField]private Image questionImageUIThird;
    [SerializeField]private Image questionImageUIFourth;
    [SerializeField]private Image questionImageUIFifth;
    [SerializeField]private List<AnswerButton> answerButtons;
    [SerializeField]private List<AnswerButton> answerButtonsSecond;
    [SerializeField]private List<AnswerButton> answerButtonsThird;
    [SerializeField]private List<AnswerButton> answerButtonsFourth;
    [SerializeField]private List<AnswerButton> answerButtonsFifth;
    [SerializeField]public Color correctCol, wrongCol, normalCol;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetQuestion(QuestionData question)
    {
        if(quizManager.questionIndex == 0 || quizManager.questionIndex == 6)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(5).gameObject.SetActive(false);
            transform.GetChild(6).gameObject.SetActive(false);
            transform.GetChild(7).gameObject.SetActive(false);
            transform.GetChild(8).gameObject.SetActive(false);
            transform.GetChild(9).gameObject.SetActive(false);
            transform.GetChild(10).gameObject.SetActive(false);

            questionImageUI.sprite = question.questionImage;

            for(int i = 0; i < answerButtons.Count; i++)
            {
                if(question.answers[i].answerImage != null)
                {
                    answerButtons[i].transform.GetChild(0).gameObject.SetActive(false);
                    answerButtons[i].GetComponent<Image>().sprite = question.answers[i].answerImage;
                    
                } 
                else 
                {
                    answerButtons[i].transform.GetChild(0).gameObject.SetActive(true);
                    answerButtons[i].GetComponentInChildren<Text>().text = question.answers[i].answerText;
                    
                }

                answerButtons[i].Setup(question.answers[i]);


                
            }
        }
        else if(quizManager.questionIndex == 2 || quizManager.questionIndex == 3)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(4).gameObject.SetActive(true);
            transform.GetChild(5).gameObject.SetActive(false);
            transform.GetChild(6).gameObject.SetActive(false);
            transform.GetChild(7).gameObject.SetActive(false);
            transform.GetChild(8).gameObject.SetActive(false);
            transform.GetChild(9).gameObject.SetActive(false);
            transform.GetChild(10).gameObject.SetActive(false);

            questionImageUISecond.sprite = question.questionImage;

            for(int i = 0; i < answerButtonsSecond.Count; i++)
            {
                answerButtonsSecond[i].GetComponent<Image>().sprite = question.answers[i].answerImage;

                answerButtonsSecond[i].Setup(question.answers[i]);
            }

            
        }
        else if(quizManager.questionIndex == 5 || quizManager.questionIndex == 7 || quizManager.questionIndex == 11)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(5).gameObject.SetActive(true);
            transform.GetChild(6).gameObject.SetActive(true);
            transform.GetChild(7).gameObject.SetActive(false);
            transform.GetChild(8).gameObject.SetActive(false);
            transform.GetChild(9).gameObject.SetActive(false);
            transform.GetChild(10).gameObject.SetActive(false);

            questionImageUIThird.sprite = question.questionImage;

            for(int i = 0; i < answerButtonsThird.Count; i++)
            {
                answerButtonsThird[i].GetComponent<Image>().sprite = question.answers[i].answerImage;

                answerButtonsThird[i].Setup(question.answers[i]);
            }

            
        }
        else if(quizManager.questionIndex == 1 || quizManager.questionIndex == 8)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(5).gameObject.SetActive(false);
            transform.GetChild(6).gameObject.SetActive(false);
            transform.GetChild(7).gameObject.SetActive(true);
            transform.GetChild(8).gameObject.SetActive(true);
            transform.GetChild(9).gameObject.SetActive(false);
            transform.GetChild(10).gameObject.SetActive(false);

            questionImageUIFourth.sprite = question.questionImage;

            for(int i = 0; i < answerButtonsFourth.Count; i++)
            {
                answerButtonsFourth[i].GetComponent<Image>().sprite = question.answers[i].answerImage;

                answerButtonsFourth[i].Setup(question.answers[i]);
            }

            
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(5).gameObject.SetActive(false);
            transform.GetChild(6).gameObject.SetActive(false);
            transform.GetChild(7).gameObject.SetActive(false);
            transform.GetChild(8).gameObject.SetActive(false);
            transform.GetChild(9).gameObject.SetActive(true);
            transform.GetChild(10).gameObject.SetActive(true);

            questionImageUIFifth.sprite = question.questionImage;

            for(int i = 0; i < answerButtonsFifth.Count; i++)
            {
                answerButtonsFifth[i].GetComponent<Image>().sprite = question.answers[i].answerImage;

                answerButtonsFifth[i].Setup(question.answers[i]);
            }

            
        }
        // questionTextUI.text = question.questionText;
        

        

        
    }

    public void RemovePreviousQuestion()
    {

    }

}
