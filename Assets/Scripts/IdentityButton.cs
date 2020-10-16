using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdentityButton : MonoBehaviour
{
    public GameObject Error;
    public InputField fullNameText, testTownText;
    public PlayerController player;
    public Canvas identityCanvas, interviewCanvas;
    public Text playerNameText;
    public Dropdown universityText, dayText, monthText, yearText;
    string chooseDay, chooseMonth, chooseYear, chooseUniversity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUnivValue(int value)
    {
        chooseUniversity = universityText.options[value].text;
    }

    public void SetDayValue(int value)
    {
        chooseDay = dayText.options[value].text;
    }

    public void SetMonthValue(int value)
    {
        chooseMonth = monthText.options[value].text;
    }

    public void SetYearValue(int value)
    {
        chooseYear = yearText.options[value].text;
    }

    public void SaveIdentity()
    {
        if(!string.IsNullOrEmpty(fullNameText.text) && !string.IsNullOrEmpty(testTownText.text) && !string.IsNullOrEmpty(chooseUniversity) && !string.IsNullOrEmpty(chooseDay) && !string.IsNullOrEmpty(chooseMonth) && !string.IsNullOrEmpty(chooseYear))
        {
            player.SetPlayerName(fullNameText.text);
            player.SetPlayerTownTest(testTownText.text);
            player.SetPlayerUniv(chooseUniversity);
            player.SetPlayerDateTest(string.Format("{0}-{1}-{2}", chooseDay, chooseMonth, chooseYear));

            playerNameText.text = player.GetPlayerName();

            identityCanvas.gameObject.SetActive(false);
            interviewCanvas.gameObject.SetActive(true);

            
        }
        else 
        {
            Error.SetActive(true);
            return;
        }
    }

    
}
