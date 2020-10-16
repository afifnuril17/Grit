using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NyamukController : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
            Handheld.Vibrate();
            
        }
    }
}
