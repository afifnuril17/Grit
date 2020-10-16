using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollectible : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip audioClip;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if(controller != null)
        {
            controller.SetKeyTime(controller.startTime);
            controller.CollectKey(1);
            controller.PlaySound(audioClip);
            // Debug.Log(controller.GetKeyTime());
            Destroy(gameObject);

            
        }
        
    }
}
