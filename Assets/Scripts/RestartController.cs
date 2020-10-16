using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
            controller.SetGateSemuPoint(1);
            controller.PopUpRestart();
            StartCoroutine(DelayPopUp(controller));
            // camera.transform.position = controller.startPosition;
            // foreach (GameObject enemy in enemyCollection)
            // {
            //     enemy.SetActive(false);
            // }
        }
    }

    IEnumerator DelayPopUp(PlayerController controller)
    {
        yield return new WaitForSeconds(1);
        controller.transform.position = controller.startPosition;
    }
}
