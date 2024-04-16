using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LessonContainer : MonoBehaviour
{
    //variables relacionadas con la configuración del GameObject.
    [Header("GameObject Configuration")]
    public int Lection = 0;
    public int CurrentLession = 0;
    public int TotalLession = 0;
    public bool AreaAllLessonComplete = false;

    //Esta sección contiene referencias a elementos de la interfaz de usuario.
    [Header("UI Configuration")]
    public TMP_Text StageTitle;
    public TMP_Text LessonStage;

    //variables y configuracion del Gamgeobject
    [Header("External GameObject Configuration")]
    public GameObject lessonContainer;
    public string LessonName;


    [Header("Lesson Data")]
    public ScriptableObject LessonData;


    public void Start()
    {
        //aqui se comprueba si LessonContainer es nula o no, si es diferente quiere decir que se asigno el inspector de unity
        if (lessonContainer != null)
        {
            //aqui se actualiza la interfaz de acuerdo a la leccion seleccioanada
            OnUpdateUI();
        }
        else
        {
            //aqui se envia un mensaje a la interfaz si el valor es nulo
            Debug.LogWarning("GameObject Nulo, revisa las variables de tipo GameObject LessonContainer");
        }
    }


    //Metodo que actualiza el texto en el menu de LessonContainer
     void OnUpdateUI()
    {
        //aqui se comprueba si stagetitle o lessonstage son nulos 
        if (StageTitle != null || LessonStage != null)
        {
            //aqui se actualiza el texto y este indica la leccion seleccionada
            StageTitle.text = "Leccion" + Lection;
            LessonStage.text = "Leccion" + CurrentLession + "de" + TotalLession;
        }
        else
        {
            //si lo anterior no se cumple, se mostrara un mensaje en la interfaz que no se ha asigando
            Debug.LogWarning("GameObject Nulo, revisa las variables de tipo TMP_Text");
        }
    }

    //aqui se activa y desactiva la ventana de LessonContainer
  public void EnableWindow()
    {
        OnUpdateUI();
        if (lessonContainer.activeSelf)
        {
            //Si esta activo, el objeto se desactiva
            lessonContainer.SetActive(false);
        }
        else
        {
            //aqui se activa el objeto si esta desactivado
            lessonContainer.SetActive(true);
            MainScript.instance.SetSelectedLesson(LessonName);  
        }
    }
}
