using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == Player) transform.GetComponent<Rigidbody>().useGravity = true;
    }
}
