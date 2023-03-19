using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leader2: MonoBehaviour
{
    [SerializeField] Button _mainmenu;
    [SerializeField] Button _level2;

    void Start()
    {
        _mainmenu.onClick.AddListener(mainmenu);
        _level2.onClick.AddListener(level2);
    }

    private void mainmenu()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.MainMenu);
    }

    private void level2()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Level02);
    }
}
