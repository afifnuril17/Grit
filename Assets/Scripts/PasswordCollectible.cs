using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordCollectible : MonoBehaviour
{
    public AudioClip audioClip;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if(controller != null)
        {
            controller.SetPasswordForKey(1);
            controller.PlaySound(audioClip);
            Destroy(gameObject);
        }
    }

}
