using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayController : MonoBehaviour
{
    GameObject titleObject, contentObject;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        titleObject = transform.parent.GetChild(0).gameObject;
        contentObject = transform.parent.GetChild(1).gameObject;
        animator = titleObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetContent()
    {

        if(titleObject.activeSelf && contentObject.activeSelf == false)
        {
            animator.SetTrigger("Close");
            StartCoroutine(DelayChange());
            
        }
        else if(contentObject.activeSelf)
        {
            this.gameObject.transform.parent.GetChild(1).gameObject.SetActive(false);
            this.gameObject.transform.parent.GetChild(3).gameObject.SetActive(false);
            this.gameObject.transform.parent.GetChild(2).gameObject.SetActive(true);
            this.gameObject.transform.parent.GetChild(4).gameObject.SetActive(true);
        }
    }

    IEnumerator DelayChange()
    {
        yield return new WaitForSeconds(1);
        this.gameObject.transform.parent.GetChild(0).gameObject.SetActive(false);
        this.gameObject.transform.parent.GetChild(1).gameObject.SetActive(true);
    }
}
