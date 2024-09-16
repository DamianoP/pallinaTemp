using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // da importare
public class RestartScene : MonoBehaviour{
    private void OnTriggerEnter(Collider other){
        SceneManager.LoadScene("Scenes/scena1");
    }
}
