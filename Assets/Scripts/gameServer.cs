using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class gameServer : MonoBehaviour
{
    public string current_user;
    public string password;
    private bool signed_up = true; // change back to false when deploying
    [SerializeField]private bool verified = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(initiateRequest());

    }

    // Update is called once per frame
    void Update()
    {
        if(!signed_up){
            StartCoroutine(createUser());
            signed_up = true;
            ScenesManager._username = current_user;
        }

        if(!verified){
            StartCoroutine(verifyUser());
        }
    }

    IEnumerator initiateRequest(){
        using(UnityWebRequest request = UnityWebRequest.Get("http://ec2-35-177-122-51.eu-west-2.compute.amazonaws.com:5000/api")){
            yield return request.SendWebRequest();

            if(request.result == UnityWebRequest.Result.ConnectionError){
                Debug.LogError(request.error);
            }else{
                string json = request.downloadHandler.text;
            }
        }
    }

    IEnumerator createUser(){
        writeUserData userdata = new writeUserData{
            username = current_user,
            password = password
        };

        string data = userdata.Convert();
        Debug.Log(data);

        using(UnityWebRequest request = UnityWebRequest.Put("http://ec2-35-177-122-51.eu-west-2.compute.amazonaws.com:5000/api/user/add", data)){
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();

            if(request.result == UnityWebRequest.Result.ConnectionError){
                Debug.LogError(request.error);
            }else{
                string json = request.downloadHandler.text;

                Debug.Log(json);
            }
        }
    }

    IEnumerator verifyUser(){
        writeUserData userdata = new writeUserData{
            username = current_user,
            password = password
        };

        string data = userdata.Convert();

        using(UnityWebRequest request = UnityWebRequest.Put("http://ec2-35-177-122-51.eu-west-2.compute.amazonaws.com:5000/api/user", data)){
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();

            if(request.result == UnityWebRequest.Result.ConnectionError){
                Debug.LogError(request.error);
            }else{
                string json = request.downloadHandler.text;

                if(readRequest.Read(json).message == "password matched"){
                    verified = true;
                }else{
                    Debug.Log("Incorrect username or password.");
                }
            }
        }
    }


}

public class writeUserData : MonoBehaviour
{
    public string username;
    public string password;

    public string Convert()
    {
        return JsonUtility.ToJson(this);
    }
}

[System.Serializable]
public class readUserData
{
    public string username;
    public string password;

    public static readUserData Read(string jsonString)
    {
        return JsonUtility.FromJson<readUserData>(jsonString);
    }
}

[System.Serializable]
public class readRequest{
    public string status;
    public string message;

    public static readRequest Read(string jsonString)
    {
        return JsonUtility.FromJson<readRequest>(jsonString); 
    }
}
