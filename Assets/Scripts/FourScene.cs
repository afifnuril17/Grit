using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FourScene : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController controller = other.gameObject.GetComponent<PlayerController>();
        if(controller != null && controller.GetKeyPoint() != 0)
        {
            // controller.SetStartPosition(new Vector2(-1.95f, -3.13f));
            // controller.transform.position = controller.GetStartPosition();
            SceneManager.LoadScene("WinLevelFour");
            
            
        }
    }
}
