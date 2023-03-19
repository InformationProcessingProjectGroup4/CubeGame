using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_3 : MonoBehaviour
{
    private float offset = 0f;
    Text score_text;
    [SerializeField] private GameObject Player;
    public GameObject uiScore;
    // Start is called before the first frame update
    void Start()
    {
        score_text = uiScore.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Player.GetComponent<rollPrototype>().isPaused){
            score_text.text = ((Mathf.Round((Time.timeSinceLevelLoad-offset)*100))/100).ToString();
        }else{
            offset += Time.deltaTime;
        }
    }
}
