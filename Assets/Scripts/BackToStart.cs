using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToStart : MonoBehaviour
{
    public GameObject LeaveToLobby;

    public void OnClickLeaveToLobby() {
        SceneManager.LoadScene("Lobby");
    }

}

