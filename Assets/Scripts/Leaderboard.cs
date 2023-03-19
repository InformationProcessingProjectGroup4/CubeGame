using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getValues());
    }

    //dont think i need to update for this method 

    IEnumerator getValues(){ // this function is NOT COMPLETE. FINISH THIS!!
        writeLeaderboard Leaderboard = new writeLeaderboard{
            level = 1, 
            count = 4
        };

        Debug.Log(Leaderboard.Convert());
        yield return new WaitForSeconds(1);
    }
}

public class writeLeaderboard : MonoBehaviour 
{
    public int level;
    public int count;

    public string Convert()
    {
        return "["+JsonUtility.ToJson(this)+"]";
    }
}
