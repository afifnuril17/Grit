using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSixth : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        RestClient postData = new RestClient();

        if(controller != null && controller.GetKeyPoint() != 0)
        {
            // StartCoroutine(postData.HttpPost(controller));
            SceneManager.LoadScene("SixthScene");
            // controller.transform.position = controller.GetStartPosition();
            
            
            // controller.SetCurrentLevel(2);
            // Debug.Log(postData.HttpPost(controller));
        }
    }
}
