using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public QuizManager quizManager;
    private AnswerData answerData;
    public QuizUI quizUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(AnswerData data)
    {
        answerData = data;
        
    }

    public void HandleClick()
    {
        // if(answerData.isCorrect)
        // {
        //     GetComponent<Image>().color = Color.green;
        //     Debug.Log("true");
        //     StartCoroutine(DelayAnswer());
        // }
        // else
        // {
        //     GetComponent<Image>().color = Color.red;
        //     Debug.Log("false");
        //     StartCoroutine(DelayAnswer());
        // }
        quizManager.AnswerButtonClicked(answerData.isCorrect);
        
    }

    IEnumerator DelayAnswer()
    {
        yield return new WaitForSeconds(5);
    }

}
