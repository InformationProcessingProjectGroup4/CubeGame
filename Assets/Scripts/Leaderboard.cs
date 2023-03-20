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

        if(ScenesManager._level == 1)
        {
            name1.text = ScenesManager.leadernames0[0].ToString();
            name2.text = ScenesManager.leadernames0[1].ToString(); 
            name3.text = ScenesManager.leadernames0[2].ToString();
            name4.text = ScenesManager.leadernames0[3].ToString();
            score1.text = ScenesManager.leaderscores0[0].ToString();
            score2.text = ScenesManager.leaderscores0[1].ToString();
            score3.text = ScenesManager.leaderscores0[2].ToString();
            score4.text = ScenesManager.leaderscores0[3].ToString();
        }
        else if(ScenesManager._level == 2)
        {
            name1.text = ScenesManager.leadernames1[0].ToString();
            name2.text = ScenesManager.leadernames1[1].ToString();
            name3.text = ScenesManager.leadernames1[2].ToString();
            name4.text = ScenesManager.leadernames1[3].ToString();
            score1.text = ScenesManager.leaderscores1[0].ToString();
            score2.text = ScenesManager.leaderscores1[1].ToString();
            score3.text = ScenesManager.leaderscores1[2].ToString();
            score4.text = ScenesManager.leaderscores1[3].ToString();
        }
        else
        {
            name1.text = ScenesManager.leadernames2[0].ToString();
            name2.text = ScenesManager.leadernames2[1].ToString();
            name3.text = ScenesManager.leadernames2[2].ToString();
            name4.text = ScenesManager.leadernames2[3].ToString();
            score1.text = ScenesManager.leaderscores2[0].ToString();
            score2.text = ScenesManager.leaderscores2[1].ToString();
            score3.text = ScenesManager.leaderscores2[2].ToString();
            score4.text = ScenesManager.leaderscores2[3].ToString();
        }
    }

}
