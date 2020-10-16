using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPasswordCollectible : MonoBehaviour
{
    [SerializeField]
    Canvas messageCanvas;
    public AudioClip audioClip;
    
    // Start is called before the first frame update
    void Start()
    {
        messageCanvas.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if(controller != null)
        {
            if(controller.GetPasswordForKey() != 0)
            {
                // messageCanvas.enabled = true;
                controller.SetKeyTime(controller.startTime);
                controller.CollectKey(1);
                controller.PlaySound(audioClip);
                gameObject.SetActive(false);
            } 
            else
            {
                messageCanvas.enabled = true;
            }
            
        } else 
        {
            return;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if(controller != null)
        {
            messageCanvas.enabled = false;
        }
    }
}
