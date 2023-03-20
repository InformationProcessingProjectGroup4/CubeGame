using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class win1 : MonoBehaviour
{

    public GameObject player;
    Text score_text;
    public GameObject uiScore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && !ScenesManager.win)
        {
            ScenesManager.win = true;
            ScenesManager.finish = true;
            score_text = uiScore.GetComponent<Text>();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        ScenesManager.win = false;
        ScenesManager.lose = false;
        ScenesManager.finish = false;
        ScenesManager._level = 1;
        ScenesManager._score = 0;
    }

    void Update()
    {
        if (ScenesManager.win)
        {
            ScenesManager._score = 1000/(float)Convert.ToDouble(score_text.text);
            StartCoroutine(ScenesManager.updateProgress());
            ScenesManager.Instance.LoadScene(ScenesManager.Scene.WinScreen1);
        }
    }
}
