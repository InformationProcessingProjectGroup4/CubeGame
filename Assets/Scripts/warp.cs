using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == player) player.GetComponent<rollPrototype>().changePosition = true;
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject == player) player.GetComponent<rollPrototype>().changePosition = false;
    }
    
}
