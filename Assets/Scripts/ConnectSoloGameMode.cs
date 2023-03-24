using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ConnectSoloGameMode : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TextMeshProUGUI buttonText;

    private List<writeUserData> userDataList = new List<writeUserData>();

    public void OnClickConnectSolo()
    {
        if (usernameInput.text.Length >= 1) 
        {
            ScenesManager._username = usernameInput.text;
            buttonText.text = "Connecting...";
            SceneManager.LoadScene("MainMenu");   
        }
    }

}