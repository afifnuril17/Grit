using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKeySensor : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if(controller != null)
        {
            // Debug.Log("Sensor");
        }
    }
}
