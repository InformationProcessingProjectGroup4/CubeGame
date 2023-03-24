using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class rollPrototype : MonoBehaviour
{
    private float _rollSpeed = 10;
    private bool _isMoving;
    public bool changePosition = false;
    public bool isPaused = false;

    void FixedUpdate()
    {
        if(_isMoving) return;

        if (changePosition){
            transform.position = new Vector3(-5, 1, 22);
            Debug.Log(transform.position);
        }

        if(Input.GetKey(KeyCode.A)) Assemble(Vector3.left);
        if(Input.GetKey(KeyCode.W)) Assemble(Vector3.forward);
        if(Input.GetKey(KeyCode.S)) Assemble(Vector3.back);
        if(Input.GetKey(KeyCode.D)) Assemble(Vector3.right);

        FileStream fileStream = new FileStream("controller.txt", FileMode.Open,FileAccess.ReadWrite,FileShare.ReadWrite);

        // Wrap the file stream in a StreamReader to read text data.
        StreamReader streamReader = new StreamReader(fileStream);

        string line = streamReader.ReadLine();
        Debug.Log(line);
            if (line == null)
            {
                // If we've reached the end of the file, reset the stream and start over.
                streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            }
            else
            {
                switch (line)
                    {
                        case "l":
                            Assemble(Vector3.left);
                            break;
                        case "f":
                            Assemble(Vector3.forward);
                            break;
                        case "b":
                            Assemble(Vector3.back);
                            break;
                        case "r":
                            Assemble(Vector3.right);
                            break;
                        default:
                            break;
                    }
            }


        void Assemble(Vector3 dir){

            // You want to rotate about an anchor point
            var anchor = transform.position + (Vector3.down + dir) * 0.5f; // Half a unit left and half a unit down 
            // You need to find the axis about which to rotate around, this requires a cross product
            var axis = Vector3.Cross(Vector3.up, dir); // Finds perpendicular axis, given two other axes.
            if (!isPaused){ StartCoroutine(Roll(anchor, axis)); }
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
