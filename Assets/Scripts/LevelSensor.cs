using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSensor : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        

        if(controller != null)
        {
            controller.SetCurrentLevel(1);
        }
    }
}
