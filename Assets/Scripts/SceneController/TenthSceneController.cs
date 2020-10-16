using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TenthSceneController : MonoBehaviour
{
    public PlayerController player;
    public Text goalText;

    void Start()
    {
        goalText.text = NextButton.levelTen;
    }

    public void ChangeScene()
    {
        player.SetCurrentLevel(10);
        SceneManager.LoadScene("TenthScene");
    }
}
