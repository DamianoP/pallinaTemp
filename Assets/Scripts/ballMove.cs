using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMove : MonoBehaviour{
    // Start is called before the first frame update
    private Rigidbody rb;
    
    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");
        Vector3 ballmove = new Vector3(hMove, 0f, vMove);
        rb.AddForce(ballmove);
    }
}
