using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteSensor : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if(controller != null)
        {
            controller.PassKey(1);
            Debug.Log("Route Sensor");
        }
    }
}
