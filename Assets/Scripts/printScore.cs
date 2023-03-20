using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class printScore : MonoBehaviour
{

    [SerializeField] public Text scorepnt; 
    // Start is called before the first frame update
    void Start()
    {
        scorepnt.text = ((int)ScenesManager._score).ToString();
    }
}
