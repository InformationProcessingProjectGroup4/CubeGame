using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;

public class losecondition : MonoBehaviour
{
    public Text score_text_lose;

    // Start is called before the first frame update
    void Start()
    {
        // can add the position player starts at here maybe? 
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -20 && !ScenesManager.lose)
        {
            ScenesManager.lose = true;
            ScenesManager.finish = true;
            ScenesManager._score = float.Parse(score_text_lose.text.ToString());
            ScenesManager.Instance.LoadLoseScreen();
            //Debug.Log(score_text_lose.text.ToString());
        }
    }

}

