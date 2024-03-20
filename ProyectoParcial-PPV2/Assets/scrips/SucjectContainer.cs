using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[CreateAssetMenu(fileName = "New Lesson", menuName = "ScriptableObject/NeeLesson", order = 1)]


[System.Serializable]
public class SubjectContainer
{
    //ScriptableObject sirve para crear una leccion que hereda informacion la cual puede ser alterada sin mover el codigo ya hecho

    //Este codigo es el que se hereda
    [Header("GameObject Configuration")]
    public int LeccionID = 0;

    [Header("Lesson Quest Configuration")]
    public List<Leccion1> LeccionList;


}


