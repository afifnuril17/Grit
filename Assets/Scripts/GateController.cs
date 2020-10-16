using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GateController : MonoBehaviour
{

    public AudioClip audioClip;
    // RestClient postData = new RestClient();
    string sendData;
    string jsonString;
    [SerializeField]Canvas messageCanvas;
    public Image notification;
    public PlayerController player;

    string[] listBeforeScenes = {"BeforeFirstScene", "BeforeSecondScene", "BeforeThirdScene", "BeforeFourthScene", "BeforeFifthScene", "BeforeSixthScene", "BeforeSeventhScene", "BeforeEightScene", "BeforeNinthScene", "BeforeTenthScene", "FinalScene"};
    // string rootURL = "http://game.psikologicare.com/api/game/store-score";
    void Start()
    {
        messageCanvas.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController controller = other.gameObject.GetComponent<PlayerController>();
        // RestClient postData = new RestClient();
        controller.SetGateTime(controller.startTime);
        controller.SetEnterGateStatus(1);

        if(controller != null && controller.GetKeyPoint() != 0)
        {
            SendData(controller);
            controller.PlaySound(audioClip);   
          
        }
        else 
        {
            messageCanvas.enabled = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        PlayerController controller = other.gameObject.GetComponent<PlayerController>();
        if(controller != null)
        {
            messageCanvas.enabled = false;
        }
    }

    public IEnumerator HttpPost(string playerLevelData, PlayerController controller, string levelType)
    {

        WWWForm form = new WWWForm();
        form.AddField("id_user", controller.GetPlayerId());
        form.AddField("id_game", "2");
        form.AddField("level", levelType);
        form.AddField("score", playerLevelData);
        form.AddField("tanggal", System.DateTime.Now.ToString());

        using(UnityWebRequest www = UnityWebRequest.Post(PlayerController.rootUrlScore, form))
        {

            // set your headers
            www.SetRequestHeader("Authorization", "Bearer " + controller.GetPlayerToken());
            
            yield return www.SendWebRequest();
            
            if(www.isNetworkError || www.isHttpError) {
                Debug.Log(www.error);
                Debug.Log(www.downloadHandler.text);
                SendData(controller);
            }
            else
            {
                jsonString = www.downloadHandler.text;
                Debug.Log(jsonString);
                StartCoroutine(controller.ChangeLevelCoroutine(controller.GetCurrentLevel()));
            }
        }

    }

    public IEnumerator HttpPostSkip(string playerLevelData, PlayerController controller, string levelType)
    {

        WWWForm form = new WWWForm();
        form.AddField("id_user", controller.GetPlayerId());
        form.AddField("id_game", "2");
        form.AddField("level", levelType);
        form.AddField("score", playerLevelData);
        form.AddField("tanggal", System.DateTime.Now.ToString());

        using(UnityWebRequest www = UnityWebRequest.Post(PlayerController.rootUrlScore, form))
        {

            // set your headers
            www.SetRequestHeader("Authorization", "Bearer " + controller.GetPlayerToken());
            
            yield return www.SendWebRequest();
            
            if(www.isNetworkError || www.isHttpError) {
                Debug.Log(www.error);
                Debug.Log(www.downloadHandler.text);
                SendSkipData(controller);
            }
            else
            {
                jsonString = www.downloadHandler.text;
                Debug.Log(jsonString);
                SceneManager.LoadScene(listBeforeScenes[controller.GetCurrentLevel()]);
            }
        }

    }

    public IEnumerator HttpPostGameOver(string playerLevelData, PlayerController controller, string levelType)
    {

        WWWForm form = new WWWForm();
        form.AddField("id_user", controller.GetPlayerId());
        form.AddField("id_game", "2");
        form.AddField("level", levelType);
        form.AddField("score", playerLevelData);
        form.AddField("tanggal", System.DateTime.Now.ToString());

        using(UnityWebRequest www = UnityWebRequest.Post(PlayerController.rootUrlScore, form))
        {

            // set your headers
            www.SetRequestHeader("Authorization", "Bearer " + controller.GetPlayerToken());
            
            yield return www.SendWebRequest();
            
            if(www.isNetworkError || www.isHttpError) {
                Debug.Log(www.error);
                Debug.Log(www.downloadHandler.text);
                SendDataGameOver(controller);
            }
            else
            {
                jsonString = www.downloadHandler.text;
                Debug.Log(jsonString);
                SceneManager.LoadScene("GameOverScene");
            }
        }

    }

    public string FirstLevelPost(PlayerController controller)
    {
        GoalOne scoreData = new GoalOne{
            nama_user = controller.GetPlayerName(),
            universitas = controller.GetPlayerUniv(),
            kota = controller.GetPlayerTownTest(),
            tgl_tes = controller.GetPlayerDateTest(),
            goal = controller.GetEnterGateStatus().ToString(),
            trophy = controller.GetQuestPerLevel().ToString(),
            waktu_kunci = controller.GetKeyTime(),
            waktu_gate = controller.GetGateTime(),
            skip_level = controller.GetSkipLevelStatus().ToString(),
            waktu_skip = controller.GetSkipTime(),
        };

        string playerLevelData = JsonUtility.ToJson(scoreData);
        return playerLevelData;
        

    }

    public string SecondLevelPost(PlayerController controller)
    {
        GoalTwo scoreData = new GoalTwo{
            goal= controller.GetEnterGateStatus().ToString(),
            trophy = controller.GetQuestPerLevel().ToString(),
            waktu_kunci = controller.GetKeyTime(),
            waktu_gate = controller.GetGateTime(),
            skip_level = controller.GetSkipLevelStatus().ToString(),
            waktu_skip = controller.GetSkipTime(),
        };

        string playerLevelData = JsonUtility.ToJson(scoreData);
        return playerLevelData;

    }

    public string ThirdLevelPost(PlayerController controller)
    {
        GoalThree scoreData = new GoalThree{
            goal = controller.GetEnterGateStatus().ToString(),
            trophy = controller.GetQuestPerLevel().ToString(),
            kunci_trophy = controller.GetTrophyCagePoint().ToString(),
            waktu_kunci = controller.GetKeyTime(),
            waktu_gate = controller.GetGateTime(),
            skip_level = controller.GetSkipLevelStatus().ToString(),
            waktu_skip = controller.GetSkipTime(),
        };

        string playerLevelData = JsonUtility.ToJson(scoreData);
        return playerLevelData;
    }

    public string FourthLevelPost(PlayerController controller)
    {
        Trophy trophyPoint = new Trophy {
            asli = controller.GetQuestPerLevel().ToString(),
            semu = controller.GetTrophySemuPoint().ToString(),
        };

        GoalFour scoreData = new GoalFour{
            goal = controller.GetEnterGateStatus().ToString(),
            trophy = trophyPoint,
            waktu_kunci = controller.GetKeyTime(),
            waktu_gate = controller.GetGateTime(),
            skip_level = controller.GetSkipLevelStatus().ToString(),
            waktu_skip = controller.GetSkipTime(),
        };

        string playerLevelData = JsonUtility.ToJson(scoreData);
        return playerLevelData;

    }

    public string FifthLevelPost(PlayerController controller)
    {
        GoalFive scoreData = new GoalFive{
            goal = controller.GetEnterGateStatus().ToString(),
            portal = controller.GetPortalPoint().ToString(),
            gate_semu = controller.GetGateSemuPoint().ToString(),
            trophy = controller.GetQuestPerLevel().ToString(),
            waktu_kunci = controller.GetKeyTime(),
            waktu_gate = controller.GetGateTime(),
            skip_level = controller.GetSkipLevelStatus().ToString(),
            waktu_skip = controller.GetSkipTime(),
        };

        string playerLevelData = JsonUtility.ToJson(scoreData);
        return playerLevelData;

    }

    public string SixthLevelPost(PlayerController controller)
    {
        Abstrak abstrakData = new Abstrak {
            satu = controller.GetFirstAbstract().ToString(),
            dua = controller.GetSecondAbstract().ToString(),
            tiga = controller.GetThirdAbstract().ToString(),
        };

        GoalSix scoreData = new GoalSix{
            goal = controller.GetEnterGateStatus().ToString(),
            portal = controller.GetPortalPoint().ToString(),
            gate_semu = controller.GetGateSemuPoint().ToString(),
            trophy = controller.GetQuestPerLevel().ToString(),
            waktu_kunci = controller.GetKeyTime(),
            waktu_gate = controller.GetGateTime(),
            abstrak = abstrakData,
            game_over = controller.GetGameOverStatus().ToString(),
            caring = controller.GetCaringResult().ToString(),
            ulang = controller.GetTakeAnotherChance(),
            waktu_over = controller.GetGameOverTime(),
        };

        string playerLevelData = JsonUtility.ToJson(scoreData);
        return playerLevelData;

    }

    public string SeventhLevelPost(PlayerController controller)
    {
        Abstrak abstrakData = new Abstrak {
            satu = controller.GetFirstAbstract().ToString(),
            dua = controller.GetSecondAbstract().ToString(),
            tiga = controller.GetThirdAbstract().ToString(),
        };

        GoalSeven scoreData = new GoalSeven{
            goal = controller.GetEnterGateStatus().ToString(),
            portal = controller.GetPortalPoint().ToString(),
            gate_semu = controller.GetGateSemuPoint().ToString(),
            trophy = controller.GetQuestPerLevel().ToString(),
            waktu_kunci = controller.GetKeyTime(),
            waktu_gate = controller.GetGateTime(),
            abstrak = abstrakData,
            game_over = controller.GetGameOverStatus().ToString(),
            ulang = controller.GetTakeAnotherChance(),
            waktu_over = controller.GetGameOverTime(),
        };


        string playerLevelData = JsonUtility.ToJson(scoreData);
        return playerLevelData;

    }

    public string EightLevelPost(PlayerController controller)
    {
        Abstrak abstrakData = new Abstrak {
            satu = controller.GetFirstAbstract().ToString(),
            dua = controller.GetSecondAbstract().ToString(),
            tiga = controller.GetThirdAbstract().ToString(),
        };

        GoalEight scoreData = new GoalEight{
            goal = controller.GetEnterGateStatus().ToString(),
            portal = controller.GetPortalPoint().ToString(),
            gate_semu = controller.GetGateSemuPoint().ToString(),
            trophy = controller.GetQuestPerLevel().ToString(),
            waktu_kunci = controller.GetKeyTime(),
            waktu_gate = controller.GetGateTime(),
            abstrak = abstrakData,
            game_over = controller.GetGameOverStatus().ToString(),
            caring = controller.GetCaringResult().ToString(),
            ulang = controller.GetTakeAnotherChance(),
            waktu_over = controller.GetGameOverTime(),
        };


        string playerLevelData = JsonUtility.ToJson(scoreData);
        return playerLevelData;

    }

    public string NinthLevelPost(PlayerController controller)
    {
        Abstrak abstrakData = new Abstrak {
            satu = controller.GetFirstAbstract().ToString(),
            dua = controller.GetSecondAbstract().ToString(),
            tiga = controller.GetThirdAbstract().ToString(),
        };

        GoalNine scoreData = new GoalNine{
            goal = controller.GetEnterGateStatus().ToString(),
            portal = controller.GetPortalPoint().ToString(),
            gate_semu = controller.GetGateSemuPoint().ToString(),
            trophy = controller.GetQuestPerLevel().ToString(),
            waktu_kunci = controller.GetKeyTime(),
            waktu_gate = controller.GetGateTime(),
            abstrak = abstrakData,
            game_over = controller.GetGameOverStatus().ToString(),
            ulang = controller.GetTakeAnotherChance(),
            waktu_over = controller.GetGameOverTime(),
        };

        string playerLevelData = JsonUtility.ToJson(scoreData);
        return playerLevelData;

    }

    public string TenthLevelPost(PlayerController controller)
    {
        Abstrak abstrakData = new Abstrak {
            satu = controller.GetFirstAbstract().ToString(),
            dua = controller.GetSecondAbstract().ToString(),
            tiga = controller.GetThirdAbstract().ToString(),
        };

        GoalTen scoreData = new GoalTen{
            goal = controller.GetEnterGateStatus().ToString(),
            portal = controller.GetPortalPoint().ToString(),
            gate_semu = controller.GetGateSemuPoint().ToString(),
            trophy = controller.GetQuestPerLevel().ToString(),
            waktu_kunci = controller.GetKeyTime(),
            waktu_gate = controller.GetGateTime(),
            abstrak = abstrakData,
            game_over = controller.GetGameOverStatus().ToString(),
            caring = controller.GetCaringResult().ToString(),
            ulang = controller.GetTakeAnotherChance(),
            waktu_over = controller.GetGameOverTime(),
        };


        string playerLevelData = JsonUtility.ToJson(scoreData);
        return playerLevelData;

    }

    public void SendData(PlayerController controller)
    {
        switch (controller.GetCurrentLevel())
            {
                case 1:
                    sendData = FirstLevelPost(controller);
                    Debug.Log(sendData);
                    StartCoroutine(HttpPost(sendData, controller, "Goal 1"));
                    break;
                case 2:
                    sendData = SecondLevelPost(controller);
                    StartCoroutine(HttpPost(sendData, controller, "Goal 2"));
                    break;
                case 3:
                    sendData = ThirdLevelPost(controller);
                    StartCoroutine(HttpPost(sendData, controller, "Goal 3"));
                    break;
                case 4:
                    sendData = FourthLevelPost(controller);
                    StartCoroutine(HttpPost(sendData, controller, "Goal 4"));
                    break;
                case 5:
                    sendData = FifthLevelPost(controller);
                    StartCoroutine(HttpPost(sendData, controller, "Goal 5"));
                    break;
                case 6:
                    sendData = SixthLevelPost(controller);
                    StartCoroutine(HttpPost(sendData, controller, "Goal 6"));
                    break;
                case 7:
                    sendData = SeventhLevelPost(controller);
                    StartCoroutine(HttpPost(sendData, controller, "Goal 7"));
                    break;
                case 8:
                    sendData = EightLevelPost(controller);
                    StartCoroutine(HttpPost(sendData, controller, "Goal 8"));
                    break;
                case 9:
                    sendData = NinthLevelPost(controller);
                    StartCoroutine(HttpPost(sendData, controller, "Goal 9"));
                    break;
                case 10:
                    sendData = TenthLevelPost(controller);
                    StartCoroutine(HttpPost(sendData, controller, "Goal 10"));
                    break;
                default:
                    break;
            }
    }

    public void SendDataGameOver(PlayerController controller)
    {
        switch (controller.GetCurrentLevel())
            {
                case 1:
                    sendData = FirstLevelPost(controller);
                    StartCoroutine(HttpPostGameOver(sendData, controller, "Goal 1"));
                    break;
                case 2:
                    sendData = SecondLevelPost(controller);
                    StartCoroutine(HttpPostGameOver(sendData, controller, "Goal 2"));
                    break;
                case 3:
                    sendData = ThirdLevelPost(controller);
                    StartCoroutine(HttpPostGameOver(sendData, controller, "Goal 3"));
                    break;
                case 4:
                    sendData = FourthLevelPost(controller);
                    StartCoroutine(HttpPostGameOver(sendData, controller, "Goal 4"));
                    break;
                case 5:
                    sendData = FifthLevelPost(controller);
                    StartCoroutine(HttpPostGameOver(sendData, controller, "Goal 5"));
                    break;
                case 6:
                    sendData = SixthLevelPost(controller);
                    StartCoroutine(HttpPostGameOver(sendData, controller, "Goal 6"));
                    break;
                case 7:
                    sendData = SeventhLevelPost(controller);
                    StartCoroutine(HttpPostGameOver(sendData, controller, "Goal 7"));
                    break;
                case 8:
                    sendData = EightLevelPost(controller);
                    StartCoroutine(HttpPostGameOver(sendData, controller, "Goal 8"));
                    break;
                case 9:
                    sendData = NinthLevelPost(controller);
                    StartCoroutine(HttpPostGameOver(sendData, controller, "Goal 9"));
                    break;
                case 10:
                    sendData = TenthLevelPost(controller);
                    StartCoroutine(HttpPostGameOver(sendData, controller, "Goal 10"));
                    break;
                default:
                    break;
            }
    }

    public void SendSkipData(PlayerController controller)
    {
        switch (controller.GetCurrentLevel())
            {
                case 1:
                    sendData = FirstLevelPost(controller);
                    StartCoroutine(HttpPostSkip(sendData, controller, "Goal 1"));
                    break;
                case 2:
                    sendData = SecondLevelPost(controller);
                    StartCoroutine(HttpPostSkip(sendData, controller, "Goal 2"));
                    break;
                case 3:
                    sendData = ThirdLevelPost(controller);
                    StartCoroutine(HttpPostSkip(sendData, controller, "Goal 3"));
                    break;
                case 4:
                    sendData = FourthLevelPost(controller);
                    StartCoroutine(HttpPostSkip(sendData, controller, "Goal 4"));
                    break;
                case 5:
                    sendData = FifthLevelPost(controller);
                    StartCoroutine(HttpPostSkip(sendData, controller, "Goal 5"));
                    break;
                case 6:
                    sendData = SixthLevelPost(controller);
                    StartCoroutine(HttpPostSkip(sendData, controller, "Goal 6"));
                    break;
                case 7:
                    sendData = SeventhLevelPost(controller);
                    StartCoroutine(HttpPostSkip(sendData, controller, "Goal 7"));
                    break;
                case 8:
                    sendData = EightLevelPost(controller);
                    StartCoroutine(HttpPostSkip(sendData, controller, "Goal 8"));
                    break;
                case 9:
                    sendData = NinthLevelPost(controller);
                    StartCoroutine(HttpPostSkip(sendData, controller, "Goal 9"));
                    break;
                case 10:
                    sendData = TenthLevelPost(controller);
                    StartCoroutine(HttpPostSkip(sendData, controller, "Goal 10"));
                    break;
                default:
                    break;
            }
    }
}
