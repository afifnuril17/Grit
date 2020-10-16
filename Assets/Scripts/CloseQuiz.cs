using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseQuiz : MonoBehaviour
{
    [SerializeField]
    Canvas quizCanvas;
    [SerializeField]
    PlayerController controller;

    public void Close()
    {
        quizCanvas.gameObject.SetActive(false);
        controller.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        controller.GetComponent<Rigidbody2D>().freezeRotation = true;

    } 
}
