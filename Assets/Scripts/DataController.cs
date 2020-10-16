using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        RestClient postData = new RestClient();

        if(controller != null && controller.GetKeyPoint() != 0)
        {
            // StartCoroutine(postData.HttpPost(controller));
        }
    }
}
