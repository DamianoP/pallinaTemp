using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour{
    public GameObject ball;
    private Vector3 distance;
    void Start(){ // Calcola la distanza iniziale
        distance = transform.position - ball.transform.position;
    }
    // Vincolo la distanza
    void Update(){
        transform.position = distance + ball.transform.position;
    }
}
