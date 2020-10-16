using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstSceneController : MonoBehaviour
{
    public PlayerController player;
    public Text goalText;

    void Start()
    {
        goalText.text = NextButton.levelOne;
    }

    public void ChangeScene()
    {
        player.SetCurrentLevel(1);
        SceneManager.LoadScene("FirstScene");
    }
}
