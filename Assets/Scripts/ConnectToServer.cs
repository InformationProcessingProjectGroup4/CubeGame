using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TextMeshProUGUI buttonText;

    private List<writeUserData> userDataList = new List<writeUserData>();

    public void OnClickConnect()
    {
        ScenesManager._username = usernameInput.text;
        if (usernameInput.text.Length >= 1) 
        {
            writeUserData userData = new writeUserData();
            userData.username = usernameInput.text;
            userData.password = passwordInput.text;
            userDataList.Add(userData);

            PhotonNetwork.NickName = usernameInput.text;
            buttonText.text = "Connecting...";
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public List<writeUserData> GetUserDataList()
    {
        return userDataList;
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("ServerRoom");   
    }
}