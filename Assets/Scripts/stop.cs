using UnityEngine;

public class stop : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject player;
    private bool stopAnimation = true;

    private void OnTriggerEnter(Collider other){
        if(other.gameObject == player) stopAnimation = false;
    }

    void FixedUpdate(){
        if(stopAnimation){ platform.gameObject.GetComponent<Animator>().enabled = false; }
        else { platform.gameObject.GetComponent<Animator>().enabled = true; }
    }
}
