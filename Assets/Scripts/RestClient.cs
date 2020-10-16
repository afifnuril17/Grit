using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class RestClient
{
    public string jsonString;
    string rootURL = "http://game.psikologicare.com/api/game/store-score";

    public IEnumerator HttpPost(string playerLevelData, PlayerController controller, string levelType)
    {
        // ScoreData scoreData = new ScoreData{
        //     keyPoint = controller.GetKeyPoint(),
        //     questPoint = controller.GetQuestPoint(),
        //     keySensor = controller.GetKeySensor(),
        //     questSensor = controller.GetQuestSensor(),
        // };

        // PlayerData playerData = new PlayerData{
        //     id_user = controller.GetPlayerId(),
        //     level = controller.GetCurrentLevel(),
        //     score = scoreData,
        //     tanggal = System.DateTime.Now.ToString(),
        //     id_game = 2,
        // };

        // string playerLevelData = JsonUtility.ToJson(playerData);
        // Debug.Log(playerLevelData);
        WWWForm form = new WWWForm();
        form.AddField("tanggal", System.DateTime.Now.ToString());
        form.AddField("id_user", controller.GetPlayerId());
        form.AddField("id_game", 2);
        form.AddField("level", levelType);
        form.AddField("score", playerLevelData);

        using(UnityWebRequest www = UnityWebRequest.Post("http://game.psikologicare.com/api/game/store-score", form))
        {
            // setup upload/download headers (this is what sets the json body)
            // byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(playerLevelData);
            // www.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
            // www.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();

            // set your headers
            www.SetRequestHeader("Authorization", "Bearer " + controller.GetPlayerToken());
            // Debug.Log(controller.GetPlayerToken());
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();
            
            if(www.isNetworkError || www.isHttpError) {
                Debug.Log(www.error);
                Debug.Log(www.downloadHandler.text);
            }
            else
            {
                // Debug.Log(www.downloadHandler.text);
                jsonString = www.downloadHandler.text;
                Debug.Log("hello" + jsonString);
            }
        }

    }
}
