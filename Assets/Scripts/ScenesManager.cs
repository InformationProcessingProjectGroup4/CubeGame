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
    public static string _username = "_newtest"; // default, remember to change this, actually might not have to if we overwrite this
    public static float _level = 1;
    public static float _score = 9.87f;
    public static float _levelx = 0;
    public static float _levely = 0;
    public static float _levelz = 0;
    public static int[] serverlevel = {0, 0, 0};
    public static int[] serverscores = {0, 0, 0};
    public static List<string> leadernames0;
    public static List<string> leadernames1;
    public static List<string> leadernames2;
    public static List<int> leaderscores0;
    public static List<int> leaderscores1;
    public static List<int> leaderscores2;
    public static bool _userexists = true;


    private void Awake() {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(fetchProgress());
        if (!_userexists) {
            StartCoroutine(updateProgress());
            StartCoroutine(fetchProgress());
            Debug.Log("user created");
        }
        StartCoroutine(fetchLeaderBoard());
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

    public static writeLevelData createData(int[] tmpscore, int[] tmplevel, writeprogress _lvlprog)
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

                if (progressresponse.JSONify(json).status == "error") {
                    _userexists = false;
                }
                else {
                    _userexists = true;
                    serverlevel = progressresponse.JSONify(json).level;
                    serverscores = progressresponse.JSONify(json).score;
                }
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

    public static IEnumerator fetchLeaderBoard()
    {

        leaderboardrequest prereq = new leaderboardrequest
        {
            count = 4
        };

        string data = prereq.Convert();

        using (UnityWebRequest request = UnityWebRequest.Put("http://ec2-35-177-122-51.eu-west-2.compute.amazonaws.com:5000/api/leaderboard", data))
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
                leaderboardresponse _leaderres = JsonUtility.FromJson<leaderboardresponse>(json);
                leadernames0 = _leaderres.data.username0;
                leadernames1 = _leaderres.data.username1;
                leadernames2 = _leaderres.data.username2;
                leaderscores0 = _leaderres.data.score0;
                leaderscores1 = _leaderres.data.score1;
                leaderscores2 = _leaderres.data.score2;
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

[System.Serializable]
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
}

public class sendusername
{
    public string username;

    public string Convert()
    {
        return JsonUtility.ToJson(this);
    }
}

public class leaderboardrequest
{
    public int count;

    public string Convert()
    {
        return JsonUtility.ToJson(this);
    }
}

[System.Serializable]
public class leaderboardresponse
{
    public leaderdatainstance data;
    public string status;

    public leaderboardresponse(leaderdatainstance _data, string _status) {
        this.data = _data;
        this.status = _status;
    }
}

[System.Serializable]
public class leaderdatainstance
{
    public int level0;
    public int level1;
    public int level2;
    public List<int> score0;
    public List<int> score1;
    public List<int> score2;
    public List<string> username0;
    public List<string> username1;
    public List<string> username2;

    public leaderdatainstance(int _level0, int _level1, int _level2, List<int> _score0, List<int> _score1, List<int> _score2, List<string> _username0, List<string> _username1, List<string> _username2) {
        this.level0 = _level0;
        this.level1 = _level1;
        this.level2 = _level2;
        this.score0 = _score0;
        this.score1 = _score1;
        this.score2 = _score2;
        this.username0 = _username0;
        this.username1 = _username1;
        this.username2 = _username2;
    }
}
