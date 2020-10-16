﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthLevelSensor : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        

        if(controller != null)
        {
            controller.SetCurrentLevel(6);
        }
    }
}
