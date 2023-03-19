using UnityEngine;

public class playermovement : MonoBehaviour{
    // Start is called before the first frame update - removed start because we don't care about the start state.

    public Rigidbody rb;

    public float forwardForce = 1000f; // 2000 is too fast

    public float sidewaysForce = 700f;

    // Using fixed update because we are using unity physics
    void FixedUpdate(){
        // Add some forward force in the z direction
        rb.AddForce(0, 0, forwardForce*Time.deltaTime);

        Debug.Log(forwardForce);

        if(Input.GetKey("d")){ // Event listener for right direction
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey("a")){ // Event listener for left direction
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }
    }
}
