using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnotherChanceButton : MonoBehaviour
{
    public PlayerController controller;
    public string[] listScenes = {"FirstScene", "SecondScene", "ThirdScene", "FourthScene", "FifthScene", "SixthScene", "SeventhScene", "EightScene", "NinthScene", "TenthScene"};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseNo()
    {
        if(controller.currentHealth == 0)
        {
            controller.SetGameOverStatus(1);
            controller.SetGameOverTime(controller.startTime);
        } 
        else if(controller.wastingTime > 180f)
        {
            controller.SetGameOverStatus(3);
            controller.SetGameOverTime(controller.startTime);
        } 
        else
        {
            controller.SetGameOverStatus(2);
            controller.SetGameOverTime(controller.startTime);
        }

        StartCoroutine(controller.ChangeToGameOver());
    }

    public void ChooseYes()
    {
        controller.SetTakeAnotherChance("y");
        controller.AnotherChancePoint();
        // SceneManager.LoadScene(listScenes[controller.GetCurrentLevel() - 1]);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        
    }
}
