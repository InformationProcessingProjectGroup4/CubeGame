using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stop : MonoBehaviour
{
    public GameObject platform;
    [SerializeField] private GameObject player;

    void FixedUpdate(){
        Debug.Log(player.transform);
    }
}
