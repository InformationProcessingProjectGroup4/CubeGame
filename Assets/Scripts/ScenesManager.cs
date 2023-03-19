using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    public static bool win = false;
    public static bool lose = false;
    public static bool finish = false;
    public static string _username = "_newuser"; // default, remember to change this, actually might not have to if we overwrite this
    public static float _level = 1;
    public static float _score = 9.87f;
    public static float _levelx = 0;
    public static float _levely = 0;
    public static float _levelz = 0;
    public static int[] serverlevel = {0, 0, 0};
    public static int[] serverscores = {0, 0, 0};


    private void Awake() {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(fetchProgress());
        StartCoroutine(fetchLeaderBoard(((int)_level-1), 2)); // change the count to 4 when actually playing.
        // maybe call leaderboard and progress for each scene at the start so that we can load the leaderboard with information
    }

    private void Update()
    {
        // do i need this?
    }

    public enum Scene {
        MainMenu,
        Leaderboard1, 
        Leaderboard2,
        Leaderboard3,
        Level01,
        Level02,
        Level03,
        WinScreen1,
        WinScreen2,
        WinScreen3,
        LoseScreen
    }

    public void LoadScene(Scene scene) {
        SceneManager.LoadScene(scene.ToString());
    }

    public void  LoadNewGame(){
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }
    
    public void LoadNextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLoseScreen() {
        SceneManager.LoadScene(Scene.LoseScreen.ToString());
    }

    public static writeprogress progressUpdate()
    {
        return new writeprogress
        {
            x = _levelx,
            y = _levely,
            z = _levelz
        };
    }

    public static int[] parseData(int index, int data, int[] array) // change this function to create the array for the level you require basically
    {
        array[index] = data;
        return array;
    }

    public static writeLevelData createData(int[] tmpscore, int[]tmplevel, writeprogress _lvlprog)
    {
        return new writeLevelData
        {
            username = _username,
            score = parseData((int)_level-1, (int)_score, tmpscore),
            level = parseData((int)_level - 1, 2, tmplevel),
            progress = _lvlprog.Convert(),
        };
    }

    public static IEnumerator initiateRequest()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://ec2-35-177-122-51.eu-west-2.compute.amazonaws.com:5000/api"))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                string json = request.downloadHandler.text;
                Debug.Log(json);
            }
        }
    }

    public static IEnumerator fetchProgress()
    {
        sendusername usermap = new sendusername
        {
            username = _username
        };
        string _data = usermap.Convert();
        using (UnityWebRequest request = UnityWebRequest.Put("http://ec2-35-177-122-51.eu-west-2.compute.amazonaws.com:5000/api/progress", _data))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                string json = request.downloadHandler.text;

                serverlevel = progressresponse.JSONify(json).level;
                serverscores = progressresponse.JSONify(json).score;
            }
        }
    }

    public static IEnumerator updateProgress()
    {
        string data = createData(serverscores, serverlevel, progressUpdate()).Convert(); // have to fix this part of the code too
        Debug.Log(data);
        using (UnityWebRequest request = UnityWebRequest.Put("http://ec2-35-177-122-51.eu-west-2.compute.amazonaws.com:5000/api/progress/update", data))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                string json = request.downloadHandler.text;
                Debug.Log(json);
            }
        }
    }

    public static IEnumerator fetchLeaderBoard(int level, int count)
    {

        leaderboardrequest prereq = new leaderboardrequest
        {
            level = level,
            count = count 
        };

        string[] data = { prereq.Convert() };

        string jsondata = JsonUtility.ToJson(data);

        using (UnityWebRequest request = UnityWebRequest.Put("http://ec2-35-177-122-51.eu-west-2.compute.amazonaws.com:5000/api/leaderboard", jsondata))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                string json = request.downloadHandler.text;
                Debug.Log(json);
            }
        }

    }
}

public class writeLevelData
{
    public string username;
    public int[] score;
    public int[] level;
    public string progress;

    public string Convert()
    {
        return JsonUtility.ToJson(this);
    }
}

public class writeprogress
{
    public float x;
    public float y;
    public float z;

    public string Convert()
    {
        return JsonUtility.ToJson(this);
    }
}

[System.Serializable]
public class readLevelData
{
    public string username;
    public int[] score;
    public int[] level;
    public string progress;

    public static readLevelData JSONify(string data)
    {
        return JsonUtility.FromJson<readLevelData>(data);
    }
}

public class readprogress
{
    public float x;
    public float y;
    public float z;

    public static readprogress JSONify(string data)
    {
        return JsonUtility.FromJson<readprogress>(data);
    }
}

public class progressresponse
{
    public string status;
    public int[] score;
    public int[] level;
    public string[] progress;

    public static progressresponse JSONify(string data)
    {
        return JsonUtility.FromJson<progressresponse>(data);
    }
};

public class sendusername
{
    public string username;

    public string Convert()
    {
        return JsonUtility.ToJson(this);
    }
};

public class leaderboardrequest
{
    public int level;
    public int count;

    public string Convert()
    {
        return JsonUtility.ToJson(this);
    }
}

public class leaderboardresponse
{
    public string status;
    public string level;
    public string[] players;
    public int[] scores;

    public static leaderboardresponse JSONify(string data)
    {
        return JsonUtility.FromJson<leaderboardresponse>(data);
    }
}
