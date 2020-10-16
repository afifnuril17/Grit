using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizController : MonoBehaviour
{
    [SerializeField]
    Canvas quizCanvas;
    // Start is called before the first frame update
    void Start()
    {
        // quizCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if(controller != null)
        {    
            quizCanvas.gameObject.SetActive(true);
            controller.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            // Debug.Log("hello");
            
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
            quizCanvas.gameObject.SetActive(false);
            controller.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            controller.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        }
    }
}
