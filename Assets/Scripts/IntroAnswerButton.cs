using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroAnswerButton : MonoBehaviour
{
    public NextButton controller;
    public IntroController intro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickedYes()
    {
        if(intro.questionIndex == 1)
        {
            NextButton.jawaban2 = "ya";
        }
        else if(intro.questionIndex == 9)
        {
            NextButton.jawaban10 = "ya";
        }
        else if(intro.questionIndex == 11)
        {
            NextButton.jawaban12 = "ya";
        }

        transform.parent.gameObject.SetActive(false);
        
        controller.HandleClick();
        // controller.UserAnswer(GetComponentInChildren<Text>().text);
        // controller.UserAnswer("yes");
    }

    public void ClickedNo()
    {
        if(intro.questionIndex == 1)
        {
            NextButton.jawaban2 = "tidak";
            intro.questionIndex += 1;
        }
        else if(intro.questionIndex == 9)
        {
            NextButton.jawaban10 = "tidak";
        }
        else if(intro.questionIndex == 11)
        {
            NextButton.jawaban12 = "tidak";
            intro.questionIndex += 1;
        }
        transform.parent.gameObject.SetActive(false);
        
        controller.HandleClick();


    }
}
