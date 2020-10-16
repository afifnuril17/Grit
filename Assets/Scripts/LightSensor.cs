using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSensor : MonoBehaviour
{
    [SerializeField]
    // public GameObject lightChild;
    // Start is called before the first frame update
    void Start()
    {
        // lightChild = GameObject.transform.GetChild(0).gameObject;
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
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
