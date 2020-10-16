using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntroController : MonoBehaviour
{
    public IntroUI introUI;
    public IntroQuestion[] allIntroQuestion;
    private IntroQuestion currentIntroQuestion;
    public int questionIndex;
    public PlayerController player;
    public Text playerNameText;

    // Start is called before the first frame update
    void Start()
    {
        questionIndex = 0;
        // SetCurrentIntroQuestion();
        playerNameText.text = player.GetPlayerName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentIntroQuestion()
    {
        currentIntroQuestion = allIntroQuestion[questionIndex];
        introUI.SetIntroQuestion(currentIntroQuestion);
        // questionIndex++;
    }


}
