using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roll : MonoBehaviour
{
    /* Start is called before the first frame update - removed start because we don't care about the start state.
    Using fixed update because we are using unity physics.
    You want a variable that checks if you are moving initially, call a private variable which cannot be changed externally. */

    [SerializeField] private float _rollSpeed = 3;
    private bool _isMoving;
    void Update(){

        if(_isMoving) return;

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
