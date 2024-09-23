using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 Prima di tutto è stato inserito un bottone all'interno della scena
 Quando creiamo un bottone all'interno degli Unity questo
 Avrà come figlio un testo che viene automaticamente creato dagli Unity
 Abbiamo modificato il testo scrivendo per esempio restart
 
 Abbiamo poi creato un nuovo script, Lo script ha una funzione pubblica
 La funzione pubblica può essere chiamata al di fuori dello script stesso proprio 
 perché pubblica. La funzione che abbiamo creato allo scopo di chiamare la scena1
 
 Agendo tramite l'interfaccia utente di Unity abbiamo definito che all'On Click del bottone
 Deve essere chiamata la funzione pubblica contenuta in questo script
 
  
 */
public class changeScene : MonoBehaviour
{

    public void restartGame(){
        SceneManager.LoadScene("Scenes/scena1");
    }

    public void QuitGame(){
        #if UNITY_STANDALONE
                Application.Quit();
        #endif
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
