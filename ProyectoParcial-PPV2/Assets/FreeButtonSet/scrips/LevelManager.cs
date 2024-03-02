using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [Header("LevelData")]
    public Subject lesson;
    [Header("Game Congiguration")]
    public TMP_Text QuestionTxt;
    [Header("Usar Interfaces")]
    public int QuestionAmount;
    public int CurrentQuestion;
    public string Question;
    public string CorrectAnswer;
    [Header("Current Lesson")]
    public Leccion CurrentLesson;


    // Start is called before the first frame update
    void Start()
    {
       QuestionAmount = lesson.leccionList.Count;
        LoadQuestion();
    }

    private void LoadQuestion()
    {
        //aseguramos que la pregunta este dentro de los limites 
        if (CurrentQuestion < QuestionAmount) 
        {
            //establecemos la cantidad de preguntas en la leccion
            
            //establecemos la leccion actual 
            CurrentLesson = lesson.leccionList[CurrentQuestion];
            Question = CurrentLesson.lessons;
            //establecemos la respuesta correcta
            CorrectAnswer = CurrentLesson.Opciones[CurrentLesson.correctanswer];
            //establecemos la pregunta en UI
            QuestionTxt.text = Question;
        }
        else
        {
            // si llegamos al final de las preguntas 
            Debug.Log("Fin de las preguntas");
        }
    }
    public void NextQuestion()
    {
        if (CurrentQuestion < QuestionAmount) 
        {
        //incrementamos el indice de la pregunta actual 
        CurrentQuestion++;
            //
            LoadQuestion();
        
        }
    }


}
