using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EightSceneController : MonoBehaviour
{
    public PlayerController player;
    public Text goalText;

    void Start()
    {
        goalText.text = NextButton.levelEight;
    }

    public void ChangeScene()
    {
        player.SetCurrentLevel(8);
        SceneManager.LoadScene("EightScene");
    }
}
