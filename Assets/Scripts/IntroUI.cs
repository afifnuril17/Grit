using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroUI : MonoBehaviour
{
    public Text questionIntroText;
    public List<IntroAnswerButton> answerButtonIntro;
    public Text inputTextIntro;
    public List<Text> inputForms;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIntroQuestion(IntroQuestion question)
    {
        questionIntroText.text = question.questionIntro;
        // answerButtonIntro[0].GetComponentInChildren<Text>().text = question.answerIntro.isTrue;
        // answerButtonIntro[1].GetComponentInChildren<Text>().text = question.answerIntro.isFalse;
    }
}
