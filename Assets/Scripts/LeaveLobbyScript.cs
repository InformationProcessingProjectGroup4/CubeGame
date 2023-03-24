using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaveLobbyScript : MonoBehaviour
{
    public GameObject playButton;

    public void OnClickLeaveToGameRoom() {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("ServerRoom");
    }

    

}
