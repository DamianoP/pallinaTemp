using System;
using System.Collections;
using System.Collections.Generic;
using TMPro; // serve ad usare le text mesh pro per la UI
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement; // serve a caricare le scene

public class BallMove : MonoBehaviour{
    // Le variabili pubbliche possono essere aggiornate tramite l'interfaccia utente degli Unity
    // Le variabili private possono essere gestite solo lato codice
    private Rigidbody rb;
    public float speed = 350;
    public float jumpSpeed = 15;
    private bool onTerrain = true;
    
    //La funzione start viene chiamata la prima volta che l'oggetto diventa attivo
    void Start(){
        _currentScore = 0;
        rb = GetComponent<Rigidbody>();
    }
    // La funzione update viene chiamata ad ogni frame
    // Time.deltaTime Ci permette di normalizzare i valori in particolar modo la possiamo utilizzare moltiplicando
    // dei coefficienti per il tempo in secondi che intercorre tra il frame precedente e quella attuale
    private int _jumpCounter = 0;
    public TextMeshProUGUI jumpText;
    void Update(){
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");
        Vector3 ballmove = new Vector3(hMove, 0f, vMove);
        float localSpeed= speed*Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift)){
            localSpeed *= 2;
        }
        rb.AddForce(ballmove*localSpeed);
        if (Input.GetKeyDown(KeyCode.Space) && onTerrain){ // Effettuiamo il salto solo se premiamo barra spaziatrice e siamo a terra
            onTerrain = false; // Una volta che salto mi metto la variabile a falso
            Vector3 jumpVec = new Vector3(0f, 10f, 0f);
            //float jumpSpeecLocal = jumpSpeed * Time.deltaTime;
            rb.AddForce(jumpVec*jumpSpeed);
            _jumpCounter++;
            jumpText.text = "Jumps: " + _jumpCounter;
        }
    }

    private void OnCollisionEnter(Collision collision){
        onTerrain = true; // Non appena tocco un oggetto o il pavimento mi segno che sono a terra
    }


    public AudioSource aSource;
    public AudioClip aClip; // presa da https://mixkit.co/free-sound-effects/alerts/
    private int _currentScore = 0;
    public TextMeshProUGUI textScore;

    private int _maxScore = 17;
    //IN CIMA! -> using TMPro; // serve ad usare le text mesh pro per la UI
    private void OnTriggerEnter(Collider other){
        GameObject go = other.gameObject;
        if (go.CompareTag("coinTag")){
            _currentScore++;
            textScore.text = "Score: " + _currentScore;
            aSource.PlayOneShot(aClip);
            go.SetActive(false);

            if (_currentScore >= _maxScore){
                SceneManager.LoadScene("victory"); // nome scena da caricare
            }
            
        }
    }
}
