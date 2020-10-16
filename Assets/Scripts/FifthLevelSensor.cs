using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifthLevelSensor : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        
        if(controller != null)
        {
            controller.SetCurrentLevel(5);
            // Debug.Log(controller.GetCurrentLevel());
        }
    }
}
