using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallMove : MonoBehaviour{
    // Le variabili pubbliche possono essere aggiornate tramite l'interfaccia utente degli Unity
    // Le variabili private possono essere gestite solo lato codice
    private Rigidbody rb;
    public float speed = 350;
    public float jumpSpeed = 15;
    private bool onTerrain = false;
    
    //La funzione start viene chiamata la prima volta che l'oggetto diventa attivo
    void Start(){
        rb = GetComponent<Rigidbody>();
    }
    // La funzione update viene chiamata ad ogni frame
    // Time.deltaTime Ci permette di normalizzare i valori in particolar modo la possiamo utilizzare moltiplicando
    // dei coefficienti per il tempo in secondi che intercorre tra il frame precedente e quella attuale
    void Update(){
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");
        Vector3 ballmove = new Vector3(hMove, 0f, vMove);
        float localSpeed= speed*Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift)){
            localSpeed *= 2;
        }
        rb.AddForce(ballmove*localSpeed);
        if (Input.GetKey(KeyCode.Space) && onTerrain){ // Effettuiamo il salto solo se premiamo barra spaziatrice e siamo a terra
            onTerrain = false; // Una volta che salto mi metto la variabile a falso
            Vector3 jumpVec = new Vector3(0f, 10f, 0f);
            //float jumpSpeecLocal = jumpSpeed * Time.deltaTime;
            rb.AddForce(jumpVec*jumpSpeed);
        }
    }
    private void OnCollisionStay(Collision c){
        onTerrain = true; // Non appena tocco un oggetto o il pavimento mi segno che sono a terra
    }

    public AudioSource aSource;
    public AudioClip aClip; // presa da https://mixkit.co/free-sound-effects/alerts/
    private void OnTriggerEnter(Collider other){
        GameObject go = other.gameObject;
        if (go.CompareTag("coinTag")){
            aSource.PlayOneShot(aClip);
            go.SetActive(false);
        }
    }
}
