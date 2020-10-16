using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FourthSceneController : MonoBehaviour
{
    public PlayerController player;
    public Text goalText;

    void Start()
    {
        goalText.text = NextButton.levelFour;
    }

    public void ChangeScene()
    {
        player.SetCurrentLevel(4);
        SceneManager.LoadScene("FourthScene");
    }
}
