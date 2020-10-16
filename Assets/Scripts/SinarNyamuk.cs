﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinarNyamuk : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
            Handheld.Vibrate();
        }
    }
}
