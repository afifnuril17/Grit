using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollectible : MonoBehaviour
{
    // [SerializeField]
    // Canvas messageCanvas;
    public AudioClip collectedClip;
    // Start is called before the first frame update
    void Start()
    {
        // messageCanvas.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if(controller != null)
        {
            // messageCanvas.enabled = true;
            // controller.SetTrophyTime(controller.startTime);
            controller.CollectQuestPerLevel(1);
            controller.CollectQuest(1);
            Destroy(gameObject);

            controller.PlaySound(collectedClip);
        }
    }

    // void OnTriggerExit2D(Collider2D other)
    // {
    //     PlayerController controller = other.GetComponent<PlayerController>();
    //     if(controller != null)
    //     {
    //         messageCanvas.enabled = false;
    //     }
    // }
}
