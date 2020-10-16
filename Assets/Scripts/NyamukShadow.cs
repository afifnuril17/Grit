using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NyamukShadow : MonoBehaviour
{
    public GameObject shadow;
    Animator animator;

    void Start()
    {
        // shadow = GameObject.FindGameObjectWithTag("Shadow");
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if(controller != null)
        {
            // messageCanvas.enabled = true;
            controller.SetGateSemuPoint(1);
            animator.enabled = !animator.enabled;
            StartCoroutine(DelayAnimation());
            shadow.SetActive(true);
        }
    }

    IEnumerator DelayAnimation()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
