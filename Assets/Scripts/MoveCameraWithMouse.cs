using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraWithMouse : MonoBehaviour{
    public GameObject ball;         // Riferimento alla pallina
    public float mouseSensitivity = 5.0f;  // Sensibilità del movimento del mouse
    public float distanceFromBall = 6.0f;  // Distanza della telecamera dalla pallina
    public float smoothTime = 1.0f;        // Velocità di realineamento

    private Vector3 offset;         // Offset fisso della telecamera rispetto alla pallina
    private Vector3 currentVelocity = Vector3.zero; // Variabile per l'allineamento smooth
    private float rotationY = 0f;   // Rotazione verticale (asse Y) per la telecamera
    private float rotationX = 0f;   // Rotazione orizzontale (asse X) per la telecamera
    private bool isRotating = false; // Flag per controllare se il mouse sta muovendo la telecamera

    void Start(){
        // Calcola l'offset iniziale della telecamera rispetto alla pallina
        offset = new Vector3(0, 2, -distanceFromBall); // Telecamera posizionata dietro e sopra la pallina
    }

    void Update(){
        // Controlla se il mouse viene usato per ruotare la telecamera
        if (Input.GetMouseButton(1)) {  // Tasto destro del mouse per ruotare
            isRotating = true;
            rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;
            rotationY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            rotationY = Mathf.Clamp(rotationY, -30f, 60f);  // Limita la rotazione verticale
        } else {
            isRotating = false;  // Se non si ruota, abilita il riallineamento automatico
        }

        Vector3 bPos = ball.transform.position;

        // Imposta la rotazione della telecamera in base al movimento del mouse
        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);
        Vector3 targetPosition = bPos + rotation * offset;

        // Applica la posizione e rotazione aggiornate alla telecamera
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
        transform.LookAt(bPos);  // Mantieni la telecamera sempre rivolta verso la pallina
    }
}
