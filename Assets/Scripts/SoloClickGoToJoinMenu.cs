using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoloClickGoToJoinMenu : MonoBehaviour
{

    public GameObject JoinMenuSolo;
    public GameObject MainMenu;


    public void SoloButtonClicked () 
    {
        JoinMenuSolo.SetActive(true);
        MainMenu.SetActive(false);



    }

}
