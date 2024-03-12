using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [Header("LevelData")]
    public Subject lesson;

    [Header("Usar Interfaces")]
    public TMP_Text QuestionTxt;
    public TMP_Text RespuestaCorrecta;
    public List<Options> option;
    public GameObject CheckButtom;
    public GameObject AnswerContainer;
    public Color Green;
    public Color Red;


    [Header("Game Congiguration")]
    public int QuestionAmount = 0;
    public int CurrentQuestion = 0;
    public string Question;
    public string CorrectAnswer;
    public int CorrectAnswerFromUser = 9;
   
    [Header("Current Lesson")]
    public Leccion CurrentLesson;


    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        else
        {
            Instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
       QuestionAmount = lesson.leccionList.Count;
        LoadQuestion();
        CheckPlayerState();
    }

    private void LoadQuestion()
    {
        //aseguramos que la pregunta este dentro de los limites 
        if (CurrentQuestion < QuestionAmount) 
        {
            //establecemos la cantidad de preguntas en la leccion
            CurrentLesson = lesson.leccionList[CurrentQuestion];
            
            //establecemos la leccion actual 
            Question = CurrentLesson.lessons;
            //establecemos la respuesta correcta
            CorrectAnswer = CurrentLesson.Opciones[CurrentLesson.correctanswer];
            //establecemos la pregunta en UI
            QuestionTxt.text = Question;
            //Establecemos las opciones
            for (int i = 0; i< CurrentLesson.Opciones.Count; i++)
            {
                option[i].GetComponent<Options>().OptionName = CurrentLesson.Opciones[i];
                option[i].GetComponent<Options>().OptionID = i;
                option[i].GetComponent<Options>().Updatetext();
            }
        }
        else
        {
            // si llegamos al final de las preguntas 
            Debug.Log("Fin de las preguntas");
        }
    }
    public void NextQuestion()
    {
        if (CheckPlayerState()) 
        { 
            if (CurrentQuestion < QuestionAmount) 
            {
                //revisamos si la pregunta es correcta
                bool isCorrect = CurrentLesson.Opciones[CorrectAnswerFromUser] == CorrectAnswer;
                //se activa la ventana que comprueba la respuesta de la UI
                AnswerContainer.SetActive(true);
                if (isCorrect)
                {
                    AnswerContainer.GetComponent<Image>().color = Green;
                    RespuestaCorrecta.text = "Respuesta correcta" + Question + ": " + CorrectAnswer;
                }
               else
                {
                   
                    AnswerContainer.GetComponent<Image>().color = Red;
                  RespuestaCorrecta.text = "Respuesta Incorrecta" + Question + ": " + CorrectAnswer;
                }
             //incrementamos el indice de la pregunta actual 
            CurrentQuestion++;
                // mostrar el resultado durante un tiwmpo (puedes usar una coruitine o invoke)
                //suspendera por 2.5 segundos el proceso de comprobar y cambiar la pregunta 
                StartCoroutine(ShowResultAndLoadQuestion(isCorrect));
            //cargar la nueva pregunta
            //LoadQuestion();
            //reset answer from player
            //CheckPlayerState();

                //reiniciar la respuesta del usuario
            CorrectAnswerFromUser = 9;
            }
            else
            {
            //cambio de escena
            }
        }
    }

    
    public void SetPlayerAnswer(int _answer)
    {
        CorrectAnswerFromUser = _answer;
    }

    public bool CheckPlayerState()
    {
        //activamos el boton de comprobar si el correct answer es diferente a 9
        if (CorrectAnswerFromUser != 9)
        {
            CheckButtom.GetComponent<Button>().interactable = true;
            CheckButtom.GetComponent<Image>().color = Color.white;
            return true;
        }
        else //aqui se desactiva si el correctanswerformuser es 9
        {

            CheckButtom.GetComponent<Button>().interactable = false;
            CheckButtom.GetComponent<Image>().color = Color.grey;
            return false;
        }
    }

    //funcion que inicia la corrutina la cual suspende el proceso del codigo despendiendo lo que se especifique dentro de esta misma funcion
    private IEnumerator ShowResultAndLoadQuestion (bool isCorrect)
    {
        yield return new WaitForSeconds(2.5f); //ajusta el tiempo que deseas mostrar el mensaje 

        //ocultar el contenedor de la respuesta
        AnswerContainer.SetActive(false);

        //cargar la nueva pregunta
        LoadQuestion();

        //puedes hacer esto aqui o en loadquestion
        CheckPlayerState();
    }



}
