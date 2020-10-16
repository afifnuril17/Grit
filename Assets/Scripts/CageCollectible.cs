using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageCollectible : MonoBehaviour
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
            if(controller.GetKeyCage() == 0)
            {
                messageCanvas.enabled = true;
            } else
            {
                controller.SetTrophyCagePoint(1);
                controller.CollectQuest(1);
                controller.PlaySound(audioClip);
                Destroy(gameObject);
            }
            
            
            // controller.CollectQuest(1);
            // Destroy(gameObject);
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
