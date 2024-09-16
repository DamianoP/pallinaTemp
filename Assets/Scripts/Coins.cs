using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour{

    public float coinSpeed = 5;
    private Vector3 _rotation = new Vector3(45f, 0f, 0f);
    // Update is called once per frame
    void Update()
    { // La funzione Transform
      // ci permette di applicare delle rotazioni agli oggetti
        transform.Rotate(Time.deltaTime*coinSpeed*_rotation);
    }
}
