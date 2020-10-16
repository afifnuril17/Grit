using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassQuestSensor : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if(controller != null)
        {
            controller.PassQuest(1);
            Debug.Log("Pass Quest");
        }
    }
}
