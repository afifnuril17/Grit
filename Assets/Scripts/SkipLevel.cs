using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkipLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController controller;
    public GateController gateController;
    public Image skipImage;
    string sendData;

    public void NextScene()
    {
        controller.SetSkipTime(controller.startTime);
        controller.SetSkipLevelStatus(1);
        switch (controller.GetCurrentLevel())
        {
            case 1:
                sendData = gateController.FirstLevelPost(controller);
                StartCoroutine(gateController.HttpPostSkip(sendData, controller, "Goal 1"));
                break;
            case 2:
                sendData = gateController.SecondLevelPost(controller);
                StartCoroutine(gateController.HttpPostSkip(sendData, controller, "Goal 2"));
                break;
            case 3:
                sendData = gateController.ThirdLevelPost(controller);
                StartCoroutine(gateController.HttpPostSkip(sendData, controller, "Goal 3"));
                break;
            case 4:
                sendData = gateController.FourthLevelPost(controller);
                StartCoroutine(gateController.HttpPostSkip(sendData, controller, "Goal 4"));
                break;
            case 5:
                sendData = gateController.FifthLevelPost(controller);
                StartCoroutine(gateController.HttpPostSkip(sendData, controller, "Goal 5"));
                break;
            default:
                break;
        }
        // SceneManager.LoadScene("SecondScene");
        // StartCoroutine(controller.ChangeLevelCoroutine(controller.GetCurrentLevel()));

    }

    public void NoSkip()
    {
        skipImage.gameObject.SetActive(false);
        controller.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        controller.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    public void AskSkip()
    {
        skipImage.gameObject.SetActive(true);
        controller.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
