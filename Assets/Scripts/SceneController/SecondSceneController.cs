using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SecondSceneController : MonoBehaviour
{
    public PlayerController player;
    public Text goalText;

    void Start()
    {
        goalText.text = NextButton.levelTwo;
    }

    public void ChangeScene()
    {
        player.SetCurrentLevel(2);
        SceneManager.LoadScene("SecondScene");
    }
}
