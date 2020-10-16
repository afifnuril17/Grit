using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeventhSceneController : MonoBehaviour
{
    public PlayerController player;
    public Text goalText;

    void Start()
    {
        goalText.text = NextButton.levelSeven;
    }

    public void ChangeScene()
    {
        player.SetCurrentLevel(7);
        SceneManager.LoadScene("SeventhScene");
    }
}
