using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FifthSceneController : MonoBehaviour
{
    public PlayerController player;
    public Text goalText;

    void Start()
    {
        goalText.text = NextButton.levelFive;
    }

    public void ChangeScene()
    {
        player.SetCurrentLevel(5);
        SceneManager.LoadScene("FifthScene");
    }
}
