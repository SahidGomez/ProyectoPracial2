using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [Header("LevelData")]
   
    public Subject1 Lesson;
    public Subject1 lesson;

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
    public Leccion1 CurrentLesson;


    //el metodo singleton proporciona un punto de acceso a ella  para acceder al script
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
       QuestionAmount = lesson.LeccionList.Count;
        
        LoadQuestion();
        CheckPlayerState();
    }

    private void LoadQuestion()
    {
        //aseguramos que la pregunta este dentro de los limites 
        if (CurrentQuestion < QuestionAmount) 
        {
            //establecemos la cantidad de preguntas en la leccion
            CurrentLesson= lesson.LeccionList[CurrentQuestion];
            
            //establecemos la leccion actual en la interfaz
            Question = CurrentLesson.lessons;
            //establecemos la respuesta correcta en la interfaz
            CorrectAnswer = CurrentLesson.Opciones[CurrentLesson.correctanswer];
            //establecemos la pregunta en UI
            QuestionTxt.text = Question;
            //Establecemos las diferentes opciones
            for (int i = 0; i< CurrentLesson.Opciones.Count; i++)
            {
                //aqui se actualizan las opciones que aparecen en la interfaz a las que podemos acceder cuandon cambian una por una
                option[i].GetComponent<Options>().OptionName = CurrentLesson.Opciones[i];
                //aqui se identifica una sola opcion de todas las que aparecen
                option[i].GetComponent<Options>().OptionID = i;
                //aqui se actualiza en texto si la respuesta en correcta o incorrecta
                option[i].GetComponent<Options>().Updatetext();
            }
        }
        else
        {
            // si nada de lo anterior se cumple se muestra el texto "llegamos al final de las preguntas" 
            Debug.Log("Fin de las preguntas");
        }
    }

    //con esta funcion nos hace cambiar entre preguntas 
    public void NextQuestion()
    {
        //Revisa la respuesta que selecciono el jugador
        if (CheckPlayerState()) 
        { 
            //aqui revisa si la pregunta esta dentro del limite de preguntas asigandas
            if (CurrentQuestion < QuestionAmount) 
            {
                //revisamos si la pregunta es correcta
                bool isCorrect = CurrentLesson.Opciones[CorrectAnswerFromUser] == CorrectAnswer;
                //se activa la ventana que comprueba la respuesta de la UI
                AnswerContainer.SetActive(true);
                if (isCorrect)
                {
                    //si la respuesta es correcta, la interfaz se pondra un cuadro verde
                    AnswerContainer.GetComponent<Image>().color = Green;
                    //aqui el texto acompa�ara al cuadro verde con el texto "Respuesta Correcta"
                    RespuestaCorrecta.text = "Respuesta correcta" + Question + ": " + CorrectAnswer;
                }
               else
                {
                  //si no es correcta el cuadro se pondra rojo  
                  AnswerContainer.GetComponent<Image>().color = Red;
                 //aqui el texto acompa�a el cuadro rojo con la leyenda "Respuesta Incorrecta"
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

                //reiniciar la respuesta del usuario en la interfaz
            CorrectAnswerFromUser = 9;
            }
            else
            {
            //cambio de escena
            }
        }
    }

    //Esta funcion asigana la respuesta del jugador 
    public void SetPlayerAnswer(int _answer)
    {
        //aqui se actualiza la respuesta del jugador con el valor que selecciono en la interfaz
        CorrectAnswerFromUser = _answer;
    }

    //Aqui si el jugador clickea algun boton y asi activa o desactiva los botones
    public bool CheckPlayerState()
    {
        //activamos el boton de comprobar si el correct answer es diferente a 9
        if (CorrectAnswerFromUser != 9)
        {
            //si el jugador interactua el boton "Comprobar" podra ocuparse
            CheckButtom.GetComponent<Button>().interactable = true;
            //aqui se actualiza el color de la imagen y cambia su color 
            CheckButtom.GetComponent<Image>().color = Color.white;
            return true;
        }

        else //aqui se desactiva si el correctanswerformuser es 9
        {
            //si no se interactua con las respuestas el boton no se activara y no cambiara de pregunta
            CheckButtom.GetComponent<Button>().interactable = false;
            //actualiza la imagen y cambia de color 
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
