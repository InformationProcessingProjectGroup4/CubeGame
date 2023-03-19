using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Mgr : MonoBehaviour
{
    
    [SerializeField] Button _mainmenu;
    [SerializeField] Button _leaderboard;

    void Start()
    {
        _mainmenu.onClick.AddListener(mainmenu);
        _leaderboard.onClick.AddListener(leaderboard);
    }

    private void mainmenu(){
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.MainMenu);
    }

    private void leaderboard(){
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Leaderboard1);
    }
}
