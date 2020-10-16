using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaringController : MonoBehaviour
{
    public PlayerController player;
    public Canvas caring;
    public string[] caringContent;
    public int caringIndex;
    public Text caringUI, trophyText;
    public KeyPasswordCollectible goldenKey;
    public GameObject passwordKey;
    GameObject[] trophies;
    public GameObject[] trophiesCaring;


    void Start()
    {
        caringIndex = 0;
        SetCurrentSlide();
        trophies = GameObject.FindGameObjectsWithTag("Trophy");
        // trophiesCaring = GameObject.FindGameObjectsWithTag("TrophyCare");
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if(controller != null)
        {
            if((player.GetCaringSix() == 1 && player.GetCurrentLevel() == 6) || (player.GetCaringEight() == 1 && player.GetCurrentLevel() == 8) || (player.GetCaringTen() == 1 && player.GetCurrentLevel() == 10))
            {
                controller.PopUpCaring();
                controller.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }
            else
            {
                return;
            }
            
            
        }
        
    }

    public void CloseCaring()
    {
        player.SetCaringResult(0);
        caring.gameObject.transform.GetChild(6).gameObject.SetActive(false);
        player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;

        if(player.GetCurrentLevel() == 6)
        {
            player.SetCaringSix(0);
        }
        else if(player.GetCurrentLevel() == 8)
        {
            player.SetCaringEight(0);
        } 
        else if(player.GetCurrentLevel() == 10)
        {
            player.SetCaringTen(0);
        }

        Destroy(gameObject);
        
    }

    public void SetCurrentSlide()
    {
        caringUI.GetComponent<Text>().text = caringContent[caringIndex];

        if(caringIndex == caringContent.Length - 1)
        {
            caring.gameObject.transform.GetChild(6).GetChild(4).gameObject.SetActive(true);
            caring.gameObject.transform.GetChild(6).GetChild(5).gameObject.SetActive(true);
            
            if(player.GetCurrentLevel() == 6)
            {
                caring.gameObject.transform.GetChild(6).GetChild(6).gameObject.SetActive(true);
                caring.gameObject.transform.GetChild(6).GetChild(7).gameObject.SetActive(true);
                caring.gameObject.transform.GetChild(6).GetChild(7).gameObject.GetComponent<Text>().text = player.GetQuestPoint().ToString();
            }
            
            
            caring.gameObject.transform.GetChild(6).GetChild(2).gameObject.SetActive(false);
        }
        else
        {
            caring.gameObject.transform.GetChild(6).GetChild(4).gameObject.SetActive(false);
            caring.gameObject.transform.GetChild(6).GetChild(5).gameObject.SetActive(false);
            caring.gameObject.transform.GetChild(6).GetChild(2).gameObject.SetActive(true);
            caring.gameObject.transform.GetChild(6).GetChild(6).gameObject.SetActive(false);
            caring.gameObject.transform.GetChild(6).GetChild(7).gameObject.SetActive(false);
        }

        if(caringIndex == 0)
        {
            caring.gameObject.transform.GetChild(6).GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            caring.gameObject.transform.GetChild(6).GetChild(1).gameObject.SetActive(true);
        }
        
    }

    public void NextSlide()
    {
        if(caringIndex < caringContent.Length - 1)
        {
            
            caringIndex++;
            SetCurrentSlide();
        }
        else
        {
            return;
        }
    }

    public void PreviousSlide()
    {
        if(caringIndex >= 1)
        {
            caringIndex--;
            SetCurrentSlide();
        }
        else if(caringIndex == 0)
        {
            SetCurrentSlide();
        }
        else
        {
            return;
        }
    }

    public void GiveKey()
    {
        player.SetCaringResult(1);
        player.CollectKey(0);
        player.SetPasswordForKey(0);
        goldenKey.gameObject.SetActive(true);
        passwordKey.gameObject.SetActive(true);
        caring.gameObject.transform.GetChild(6).gameObject.SetActive(false);
        player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        player.SetCaringTen(0);
        // gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void DoNotGiveKey()
    {
        player.SetCaringResult(0);
        caring.gameObject.transform.GetChild(6).gameObject.SetActive(false);
        player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        player.SetCaringTen(0);
        // gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void EightTrophy()
    {
        player.SetCaringResult(8);
        player.MinusCollectQuest(8);
        caring.gameObject.transform.GetChild(6).gameObject.SetActive(false);
        caring.gameObject.transform.GetChild(9).gameObject.SetActive(true);
        trophyText.text = player.GetQuestPoint().ToString();
        
    }

    public void ThirdTrophy()
    {
        player.SetCaringResult(3);
        player.MinusCollectQuest(3);
        caring.gameObject.transform.GetChild(6).gameObject.SetActive(false);
        caring.gameObject.transform.GetChild(9).gameObject.SetActive(true);
        trophyText.text = player.GetQuestPoint().ToString();
        // player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        // player.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        // gameObject.SetActive(false);
    }

    public void PositionToRandom()
    {
        player.SetCaringResult(1);
        player.transform.position = new Vector3(10.52f, 17.29f, 0);
        caring.gameObject.transform.GetChild(6).gameObject.SetActive(false);
        player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        player.SetCaringEight(0);
        // gameObject.SetActive(false);
        Destroy(gameObject);
        foreach (GameObject trophy in trophies)
        {
            trophy.SetActive(false);
        }
        trophiesCaring[0].SetActive(true);
    }

    public void PositionToStart()
    {
        player.SetCaringResult(2);
        player.transform.position = player.startPosition;
        caring.gameObject.transform.GetChild(6).gameObject.SetActive(false);
        player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        player.SetCaringEight(0);
        // gameObject.SetActive(false);
        Destroy(gameObject);
        foreach (GameObject trophy in trophies)
        {
            trophy.SetActive(false);
        }
        foreach (GameObject trophyCaring in trophiesCaring)
        {
            trophyCaring.SetActive(true);
        }
    }

    public void CloseAfterCaring()
    {
        caring.gameObject.transform.GetChild(9).gameObject.SetActive(false);
        player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        player.SetCaringSix(0);
        // gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
