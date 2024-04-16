using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{

    //metodo para cargar la escena de creditos
   public void creditos ()
    {
        //carga la siguiente escena en el orden que se puso
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        //muestra el texto SALIR y se termina el juego
        Debug.Log("Salir...");
        //cierra la aplicacion 
        Application.Quit();
    }

}
