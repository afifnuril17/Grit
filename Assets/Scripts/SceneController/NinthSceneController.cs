using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NinthSceneController : MonoBehaviour
{
    public PlayerController player;
    public Text goalText;

    void Start()
    {
        goalText.text = NextButton.levelNine;
    }

    public void ChangeScene()
    {
        player.SetCurrentLevel(9);
        SceneManager.LoadScene("NinthScene");
    }
}
