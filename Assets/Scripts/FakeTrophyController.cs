using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeTrophyController : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        PlayerController controller = other.GetComponent<PlayerController>();
        if(controller != null)
        {
            // messageCanvas.enabled = true;
            controller.SetTrophySemuPoint(1);
            animator.enabled = !animator.enabled;
            StartCoroutine(DelayAnimation());
            
        }
    }

    IEnumerator DelayAnimation()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
