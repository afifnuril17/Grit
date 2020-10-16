using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SixthSceneController : MonoBehaviour
{
    public PlayerController player;
    public Text goalText;

    void Start()
    {
        goalText.text = NextButton.levelSix;
    }
    
    public void ChangeScene()
    {
        player.SetCurrentLevel(6);
        SceneManager.LoadScene("SixthScene");
    }
}
