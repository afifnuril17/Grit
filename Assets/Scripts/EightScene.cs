﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EightScene : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController controller = other.gameObject.GetComponent<PlayerController>();
        if(controller != null && controller.GetKeyPoint() != 0)
        {
            SceneManager.LoadScene("WinLevelEight");
            
            
        }
    }
}
