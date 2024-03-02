using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LessonContainer : MonoBehaviour
{

    [Header("GameObject Configuration")]
    public int Lection = 0;
    public int CurrentLession = 0;
    public int TotalLession = 0;
    public bool AreaAllLessonComplete = false;


    [Header("UI Configuration")]
    public TMP_Text StageTitle;
    public TMP_Text LessonStage;


    [Header("External GameObject Configuration")]
    public GameObject lessonContainer;


    [Header("Lesson Data")]
    public ScriptableObject LessonData;


    void Start()
    {
        if (lessonContainer != null)
        {
            OnUpdateUI();
        }
        else
        {
            Debug.LogWarning("GameObject Nulo, revisa las variables de tipo GameObject LessonContainer");
        }
    }

     void OnUpdateUI()
    {
        if (StageTitle != null || LessonStage != null)
        {
            StageTitle.text = "Leccion" + Lection;
            LessonStage.text = "Leccion" + CurrentLession + "de" + TotalLession;
        }
        else
        {
            Debug.LogWarning("GameObject Nulo, revisa las variables de tipo TMP_Text");
        }
    }

  public void EnableWindow()
    {
        OnUpdateUI();
        if (lessonContainer.activeSelf)
        {
            lessonContainer.SetActive(false);
        }
        else
        {
            lessonContainer.SetActive(true);
        }
    }
}
