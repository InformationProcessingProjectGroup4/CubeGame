using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Text name1;
    public Text name2;
    public Text name3;
    public Text name4;
    public Text score1;
    public Text score2;
    public Text score3;
    public Text score4;
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(ScenesManager._level);
    }

}
