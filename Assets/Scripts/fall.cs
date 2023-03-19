using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == Player) StartCoroutine(Wait());
    }

    IEnumerator Wait(){
    yield return new WaitForSeconds(0.5f);
    transform.GetComponent<Rigidbody>().useGravity = true;
    transform.GetComponent<Rigidbody>().isKinematic = false;
    }

}
