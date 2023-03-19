using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leader3: MonoBehaviour
{
    [SerializeField] Button _mainmenu;
    [SerializeField] Button _level3;

    void Start()
    {
        _mainmenu.onClick.AddListener(mainmenu);
        _level3.onClick.AddListener(level3);
    }

    private void mainmenu()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.MainMenu);
    }

    private void level3()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Level03);
    }
}
