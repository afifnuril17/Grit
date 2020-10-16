using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaringUI : MonoBehaviour
{
    public Text[] slideCaring;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetContent(string content)
    {
        for(int i = 0; i < slideCaring.Length; i++)
        {
            slideCaring[i].GetComponent<Text>().text = content;
        }
    }
}
