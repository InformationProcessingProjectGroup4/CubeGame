using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stop : MonoBehaviour
{
    public GameObject platform;
    [SerializeField]private bool stopAnimation = true;

    // Update is called once per frame
    void Update()
    {
        if(stopAnimation){ platform.GetComponent<Animator>().enabled = false; }
        else { platform.GetComponent<Animator>().enabled = true; }

    }
}
