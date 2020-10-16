using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class NextButton : MonoBehaviour
{
    public IntroController controller;
    public PlayerController player;
    public Text userName, notifText; 
    public InputField inputText;
    public List<string> answerCollection;
    string userInput;
    int currentQuestionIndex = 0;
    public InputField firstGoal, secondGoal, thirdGoal, fourthGoal, fifthGoal, sixthGoal, seventhGoal, eightGoal, ninthGoal, tenthGoal;
    string sendData;
    public string jsonString;
    public static string jawaban1, jawaban2, jawaban3, jawaban4, jawaban5, jawaban6, jawaban8, jawaban9, jawaban10, jawaban11, jawaban12, jawaban13, levelOne, levelTwo, levelThree, levelFour, levelFive, levelSix, levelSeven, levelEight, levelNine, levelTen;
    // RestClient postData = new RestClient();
    // Goal jawaban7 = new Goal();
    // Interview dataInterview = new Interview();

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleClick()
    {
        if(!string.IsNullOrEmpty(inputText.text))
        {
            // currentQuestionIndex = controller.questionIndex;
            if(controller.questionIndex < controller.allIntroQuestion.Length - 1)
            {
                
            
                if(controller.questionIndex == 0)
                {
                    jawaban1 = inputText.text;
                    
                }
                else if(controller.questionIndex == 2)
                {
                    if(jawaban2 == "ya")
                    {
                        jawaban3 = inputText.text;
                    }
                    else
                    {
                        jawaban3 = null;
                    }
                    
                   
                }
                else if(controller.questionIndex == 3)
                {
                    jawaban4 = inputText.text;
                    
                }
                else if(controller.questionIndex == 4)
                {
                    jawaban5 = inputText.text;
                    
                }
                else if(controller.questionIndex == 5)
                {
                    jawaban6 = inputText.text;
                    
                }
                else if(controller.questionIndex == 7)
                {
                    jawaban8 = inputText.text;
                    
                }
                else if(controller.questionIndex == 8)
                {
                    jawaban9 = inputText.text;
                     
                }
                else if(controller.questionIndex == 10)
                {
                    jawaban11 = inputText.text;
                     
                }
                
                controller.questionIndex++;

                
                controller.SetCurrentIntroQuestion();

                if(controller.questionIndex == 0)
                {
                    transform.parent.GetChild(11).gameObject.SetActive(false);
                }
                else
                {
                    transform.parent.GetChild(11).gameObject.SetActive(true);
                }

                if(controller.questionIndex == controller.allIntroQuestion.Length)
                {
                    transform.parent.GetChild(10).gameObject.SetActive(false);
                }
                else
                {
                    transform.parent.GetChild(10).gameObject.SetActive(true);
                }

                
                

                if(controller.questionIndex % 2 == 0)
                {
                    transform.parent.GetChild(1).gameObject.SetActive(true);
                    transform.parent.GetChild(2).gameObject.SetActive(false);
                }
                else
                {
                    transform.parent.GetChild(2).gameObject.SetActive(true);
                    transform.parent.GetChild(1).gameObject.SetActive(false);
                }

                if(controller.questionIndex == 1 || controller.questionIndex == 9 || controller.questionIndex == 11)
                {   
                    transform.parent.GetChild(7).gameObject.SetActive(false);
                    transform.parent.GetChild(8).gameObject.SetActive(false);
                    transform.parent.GetChild(6).gameObject.SetActive(true);
                    transform.parent.GetChild(10).gameObject.SetActive(false);
                }
                else if(controller.questionIndex == 6)
                {
                    transform.parent.GetChild(6).gameObject.SetActive(false);
                    transform.parent.GetChild(7).gameObject.SetActive(false);
                    transform.parent.GetChild(8).gameObject.SetActive(true);
                    transform.parent.GetChild(10).gameObject.SetActive(false);
                    
                }
                else
                {
                    transform.parent.GetChild(6).gameObject.SetActive(false);
                    transform.parent.GetChild(8).gameObject.SetActive(false);
                    transform.parent.GetChild(7).gameObject.SetActive(true);


                    userInput = transform.parent.GetChild(7).gameObject.GetComponentInChildren<InputField>().text;
                    if(!string.IsNullOrEmpty(userInput))
                    {
                        UserAnswer(userInput);
                        transform.parent.GetChild(7).gameObject.GetComponentInChildren<InputField>().text = "";
                        
                    }    
                    
                }
            
           
                
            }
            else
            {
                transform.parent.GetChild(5).gameObject.SetActive(false);
                transform.parent.GetChild(7).gameObject.SetActive(false);
                transform.parent.GetChild(10).gameObject.SetActive(false);
                transform.parent.GetChild(11).gameObject.SetActive(false);
                transform.parent.GetChild(14).gameObject.SetActive(true);
                transform.parent.GetChild(15).gameObject.SetActive(true);
            }

            if(controller.questionIndex == 12)
            {
                jawaban13 = inputText.text;
                    
            }
        }
        else 
        {
        return;
        }   
    }

    public void PreviousClick()
    {
        // controller.questionIndex = currentQuestionIndex;
        

        if(controller.questionIndex >= 1)
        {
                controller.questionIndex--;
                controller.SetCurrentIntroQuestion();

                if(controller.questionIndex % 2 == 0)
                {
                    transform.parent.GetChild(1).gameObject.SetActive(true);
                    transform.parent.GetChild(2).gameObject.SetActive(false);
                }
                else
                {
                    transform.parent.GetChild(2).gameObject.SetActive(true);
                    transform.parent.GetChild(1).gameObject.SetActive(false);
                }

                if(controller.questionIndex == controller.allIntroQuestion.Length)
                {
                    transform.parent.GetChild(10).gameObject.SetActive(false);
                }
                else
                {
                    transform.parent.GetChild(10).gameObject.SetActive(true);
                }

                if(controller.questionIndex == 0)
                {
                    transform.parent.GetChild(11).gameObject.SetActive(false);
                }
                else
                {
                    transform.parent.GetChild(11).gameObject.SetActive(true);
                }

               

                if(controller.questionIndex == 1 || controller.questionIndex == 9 || controller.questionIndex == 11)
                {   
                    transform.parent.GetChild(7).gameObject.SetActive(false);
                    transform.parent.GetChild(8).gameObject.SetActive(false);
                    transform.parent.GetChild(6).gameObject.SetActive(true);
                    transform.parent.GetChild(10).gameObject.SetActive(false);
                    // controller.SetPreviousIntroQuestion();
                }
                else if(controller.questionIndex == 6)
                {
                    transform.parent.GetChild(6).gameObject.SetActive(false);
                    transform.parent.GetChild(7).gameObject.SetActive(false);
                    transform.parent.GetChild(8).gameObject.SetActive(true);
                    transform.parent.GetChild(10).gameObject.SetActive(false);
                    // controller.SetPreviousIntroQuestion();
                }
                else
                {
                    transform.parent.GetChild(6).gameObject.SetActive(false);
                    transform.parent.GetChild(8).gameObject.SetActive(false);
                    transform.parent.GetChild(7).gameObject.SetActive(true);


                    userInput = transform.parent.GetChild(7).gameObject.GetComponentInChildren<InputField>().text;
                    if(!string.IsNullOrEmpty(userInput))
                    {
                        UserAnswer(userInput);
                        transform.parent.GetChild(7).gameObject.GetComponentInChildren<InputField>().text = "";
                        
                    }        
                    
                }
        }
        else if(controller.questionIndex == 0)
        {
            controller.SetCurrentIntroQuestion();
        }
        else
        {
            return;
        }
    }

    public void OkButton()
    {
       
            transform.parent.GetChild(4).gameObject.SetActive(false);
            transform.parent.GetChild(5).gameObject.SetActive(true);
            transform.parent.GetChild(10).gameObject.SetActive(true);
            transform.parent.GetChild(7).gameObject.SetActive(true);
            transform.parent.GetChild(16).gameObject.SetActive(false);
            controller.SetCurrentIntroQuestion();
            
    }

    public void FormButtonClicked()
    {
        transform.parent.GetChild(8).gameObject.SetActive(false);
        transform.parent.GetChild(13).gameObject.SetActive(true);
    }

    public void SaveForm()
    {
        if(!string.IsNullOrEmpty(firstGoal.text) && !string.IsNullOrEmpty(secondGoal.text) && !string.IsNullOrEmpty(thirdGoal.text) && !string.IsNullOrEmpty(fourthGoal.text) && !string.IsNullOrEmpty(fifthGoal.text) && !string.IsNullOrEmpty(sixthGoal.text) && !string.IsNullOrEmpty(seventhGoal.text) && !string.IsNullOrEmpty(eightGoal.text) && !string.IsNullOrEmpty(ninthGoal.text) && !string.IsNullOrEmpty(tenthGoal.text))
        {
            levelOne = firstGoal.text;
            levelTwo = secondGoal.text;
            levelThree = thirdGoal.text;
            levelFour = fourthGoal.text;
            levelFive = fifthGoal.text;
            levelSix = sixthGoal.text;
            levelSeven = seventhGoal.text;
            levelEight = eightGoal.text;
            levelNine = ninthGoal.text;
            levelTen = tenthGoal.text;

            transform.parent.GetChild(13).gameObject.SetActive(false);
            
            HandleClick();
        }
    }

    public void CloseForm()
    {
        ClearArea();
        transform.parent.GetChild(13).gameObject.SetActive(false);
        transform.parent.GetChild(8).gameObject.SetActive(true);
    }

    public void StartGame()
    {
        
        sendData = InterviewPost();
        // Debug.Log(sendData);
        StartCoroutine(HttpPost(sendData, player, "wawancara"));
        
        
    }

    public void UserAnswer(string answer)
    {
        answerCollection.Add(answer);
        // Debug.Log(answerCollection.Count);
    }

    string InterviewPost()
    {
        Goal jawaban7 = new Goal {
            goal1 = levelOne,
            goal2 = levelTwo,
            goal3 = levelThree,
            goal4 = levelFour,
            goal5 = levelFive,
            goal6 = levelSix,
            goal7 = levelSeven,
            goal8 = levelEight,
            goal9 = levelNine,
            goal10 = levelTen,
        };

        Interview dataInterview = new Interview {
            nama_user = player.GetPlayerName(),
            universitas = player.GetPlayerUniv(),
            kota = player.GetPlayerTownTest(),
            tgl_tes = player.GetPlayerDateTest(),
            pertanyaan1 = jawaban1,
            pertanyaan2 = jawaban2,
            pertanyaan3 = jawaban3,
            pertanyaan4 = jawaban4,
            pertanyaan5 = jawaban5,
            pertanyaan6 = jawaban6,
            pertanyaan7 = jawaban7,
            pertanyaan8 = jawaban8,
            pertanyaan9 = jawaban9,
            pertanyaan10 = jawaban10,
            pertanyaan11 = jawaban11,
            pertanyaan12 = jawaban12,
            pertanyaan13 = jawaban13,
        };

        string playerLevelData = JsonUtility.ToJson(dataInterview);
        return playerLevelData;
    }

    public IEnumerator HttpPost(string playerLevelData, PlayerController controller, string levelType)
    {
        WWWForm form = new WWWForm();
        form.AddField("tanggal", System.DateTime.Now.ToString());
        form.AddField("id_user", controller.GetPlayerId());
        form.AddField("id_game", 2);
        form.AddField("level", levelType);
        form.AddField("score", playerLevelData);

        using(UnityWebRequest www = UnityWebRequest.Post(PlayerController.rootUrlScore, form))
        {
            // setup upload/download headers (this is what sets the json body)
            // byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(playerLevelData);
            // www.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
            // www.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();

            // set your headers
            www.SetRequestHeader("Authorization", "Bearer " + controller.GetPlayerToken());
            // Debug.Log(controller.GetPlayerToken());
            // www.SetRequestHeader("Content-Type", "application/json");
            // www.chunkedTransfer = false;
            yield return www.SendWebRequest();
            
            if(www.isNetworkError || www.isHttpError) {
                Debug.Log(www.error);
                Debug.Log(www.downloadHandler.text);
                transform.parent.GetChild(17).gameObject.SetActive(true);
            }
            else
            {
                // Debug.Log(www.downloadHandler.text);
                jsonString = www.downloadHandler.text;
                Debug.Log(jsonString);
                StartCoroutine(StartGameCoroutine());
            }
        }

    }

    public IEnumerator StartGameCoroutine()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("BeforeGameScene");
    }

    void ClearArea()
    {
            firstGoal.text = "";
            secondGoal.text = "";
            thirdGoal.text = "";
            fourthGoal.text = "";
            fifthGoal.text = "";
            sixthGoal.text = "";
            seventhGoal.text = "";
            eightGoal.text = "";
            ninthGoal.text = "";
            tenthGoal.text = "";
    }
}
