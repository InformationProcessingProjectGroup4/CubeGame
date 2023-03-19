using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button _level1;
    [SerializeField] Button _level2;
    [SerializeField] Button _level3;
    [SerializeField] Button _lobby;
    
    void Start()
    {
        _level1.onClick.AddListener(load1);
        _level2.onClick.AddListener(load2);
        _level3.onClick.AddListener(load3);
        _lobby.onClick.AddListener(loadlobby);
    }

    private void load1(){
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Level01);
    }
    private void load2(){
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Level02);
    }
    private void load3(){
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Level03);
    }
    private void loadlobby(){

    }
}
