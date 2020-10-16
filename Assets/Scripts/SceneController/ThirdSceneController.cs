using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThirdSceneController : MonoBehaviour
{
    public PlayerController player;
    public Text goalText;

    void Start()
    {
        goalText.text = NextButton.levelThree;
    }

    public void ChangeScene()
    {
        player.SetCurrentLevel(3);
        SceneManager.LoadScene("ThirdScene");
    }
}
