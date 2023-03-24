using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToStartScreen : MonoBehaviour
{
    public GameObject LeaveToStartScreen;

    public void OnClickLeaveToLobby() {
        SceneManager.LoadScene("Lobby");
    }

}

