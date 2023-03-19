using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leader1 : MonoBehaviour
{
    [SerializeField] Button _mainmenu;
    [SerializeField] Button _level1;

    void Start()
    {
        _mainmenu.onClick.AddListener(mainmenu);
        _level1.onClick.AddListener(level1);
    }

    private void mainmenu()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.MainMenu);
    }

    private void level1()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Level01);
    }
}
