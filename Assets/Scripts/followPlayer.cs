using UnityEngine;

public class followPlayer : MonoBehaviour
{

    // This script allows you to follow the player using the camera

    public Transform player;

    // Update is called once per frame
    void Update(){
        transform.position = player.position + new Vector3(0, 2, -6); // This is so that we don't have a first person perspective
        // have changed this script so as to view the cube from the top
    }

}
