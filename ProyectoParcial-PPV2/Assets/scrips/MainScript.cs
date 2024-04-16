using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
    public static MainScript instance;
    public string SelectedLesson = "Dummy";

    private void Awake()
    {
        //Comprueba si hay una instancia de SaveSystem en el codigo
        if (instance != null)
        {
            //Si ya existe una instancia, sale del método Awake
            return;
        }
        else
        {
            instance = this;
        }
    }
    
    public void SetSelectedLesson(string lesson)
    { 
        //asigna el valor a la variable
        SelectedLesson = lesson; 
        //guarda los datos entre escenas
        PlayerPrefs.SetString("SelectedLesson", SelectedLesson);
    }

    //inicia el juego
    public void BeginGame()
    {
        //Se carga la escena "Lesson" en la interfaz
        SceneManager.LoadScene("Lesson");
    }


}
