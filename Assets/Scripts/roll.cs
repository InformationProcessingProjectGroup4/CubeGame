using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roll : MonoBehaviour
{
    /* Start is called before the first frame update - removed start because we don't care about the start state.
    Using fixed update because we are using unity physics.
    You want a variable that checks if you are moving initially, call a private variable which cannot be changed externally. */

    private float _rollSpeed = 7;
    private bool _isMoving;
    public Transform Player;

    private float xanc = 18.7f;
    private float yanc = 5.4f;
    private float zanc = 8.2f;

    void FixedUpdate(){

        if(_isMoving) return;

        if(transform.position.x > xanc && transform.position.z > zanc){ // helps in climbing the platform, might have to make this script exclusive to level 3
            if(transform.position.z < 9.5f){
                if(transform.position.y < yanc){
                    Player.GetComponent<Rigidbody>().drag = 20;
                }
            }else{
                    Player.GetComponent<Rigidbody>().drag = 0;
                }
        }else{
            Player.GetComponent<Rigidbody>().drag = 0;
        }

        if(Input.GetKey(KeyCode.A)) Assemble(Vector3.left);
        if(Input.GetKey(KeyCode.W)) Assemble(Vector3.forward);
        if(Input.GetKey(KeyCode.S)) Assemble(Vector3.back);
        if(Input.GetKey(KeyCode.D)) Assemble(Vector3.right);

        void Assemble(Vector3 dir){

            // You want to rotate about an anchor point
            var anchor = transform.position + (Vector3.down + dir) * 0.5f; // Half a unit left and half a unit down 
            // You need to find the axis about which to rotate around, this requires a cross product
            var axis = Vector3.Cross(Vector3.up, dir); // Finds perpendicular axis, given two other axes.
            StartCoroutine(Roll(anchor, axis));
        }
    }

    IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        _isMoving = true;
        for(int i = 0; i <(90/_rollSpeed); i++){
            transform.RotateAround(anchor, axis, _rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        _isMoving = false;
    }
}
