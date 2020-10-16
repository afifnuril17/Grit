using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class LoginData 
{
    public string token;
    public string user_id;
    public string name;
    public Attribute attribute;
}

[System.Serializable]
public class Attribute 
{
    public Data nama;
    public Data tgl_lahir;
    public Data kota_tes;
    public Data tanggal_tes;
    public Data jurusan_kuliah;
    public Data universitas;
    public Data beasiswa_teladan;
    public Data cita_cita;
}

[System.Serializable]
public class Data 
{
    public string attribute;
    public string label;
    public string type;
    public string validator;
}

public class LoginSystem : MonoBehaviour
{
    public GameObject ErrorLogin;

    public PlayerController controller;
    public InputField username, password;

    string loginEmail = "";
    string loginPassword = "";
    string errorMessage = "";
    string responseText;

    // string rootURL;

    public void SubmitLogin() 
    {

        loginEmail = username.text;
        loginPassword = password.text;

        StartCoroutine(LoginEnumerator(loginEmail, loginPassword));

        // Debug.Log(loginPassword);
    }


    IEnumerator LoginEnumerator(string userName, string userPassword) 
    {
        
        errorMessage = "";

        WWWForm form = new WWWForm();
        form.AddField("name", userName);
        form.AddField("password", userPassword);

        using (UnityWebRequest www = UnityWebRequest.Post(PlayerController.rootUrlLogin, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                ErrorLogin.SetActive(true);
                errorMessage = www.error;
                // Debug.Log(errorMessage);
            }
            else
            {
                responseText = www.downloadHandler.text;
                LoginData loginData = new LoginData();
                loginData = JsonUtility.FromJson<LoginData>(responseText);
                controller.SetPlayerToken(loginData.token);
                controller.SetPlayerId(loginData.user_id);
                // controller.SetPlayerName(loginData.name);
                // controller.SetCurrentLevel(1);
                // Debug.Log(controller.GetPlayerToken());
                // Debug.Log(controller.GetPlayerId());

                ResetValues();
                SceneManager.LoadScene("IntroScene");        
                    
            }
        
        }

    }

    void ResetValues()
    {
        errorMessage = "";
        loginEmail = "";
        loginPassword = "";
    }

    public void SeePassword()
    {
        if(password.GetComponent<InputField>().contentType == InputField.ContentType.Standard)
        {
            password.GetComponent<InputField>().contentType = InputField.ContentType.Password;
            
        }
        else if(password.GetComponent<InputField>().contentType == InputField.ContentType.Password)
        {
            password.GetComponent<InputField>().contentType = InputField.ContentType.Standard;
            
        }

        password.ForceLabelUpdate ();
        password.text = password.text;
    }
    
}





