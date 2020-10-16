using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeforeFirstSceneController : MonoBehaviour
{
   public void ChangeScene()
    {
        SceneManager.LoadScene("BeforeFirstScene");
    }
}
