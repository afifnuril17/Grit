using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    GameObject[] enemyCollection;
    public Canvas textPortal;
    GameObject portalGate;
    public PlayerController player;
    // GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        enemyCollection = GameObject.FindGameObjectsWithTag("Enemy");
        portalGate = GameObject.FindGameObjectWithTag("Portal");
        // camera = GameObject.FindGameObjectWithTag("MainCamera");
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
            // controller.transform.position = controller.startPosition;
            // // camera.transform.position = controller.startPosition;
            // foreach (GameObject enemy in enemyCollection)
            // {
            //     enemy.SetActive(false);
            // }
            textPortal.gameObject.transform.GetChild(5).gameObject.SetActive(true);
            player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    public void ClickYes()
    {
        player.SetPortalPoint(1);
        player.transform.position = player.startPosition;
        player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        textPortal.gameObject.transform.GetChild(5).gameObject.SetActive(false);

            // camera.transform.position = controller.startPosition;
        foreach (GameObject enemy in enemyCollection)
        {
            enemy.SetActive(false);
        }

        portalGate.SetActive(false);
        
    }

    public void ClickNo()
    {
        textPortal.gameObject.transform.GetChild(5).gameObject.SetActive(false);
        player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;

    }
}
