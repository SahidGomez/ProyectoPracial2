using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class Options : MonoBehaviour
{
    public int OptionID;
    public string OptionName;
   

    //El TMP Text se actualiza al texto que tiene la siguiente la siguiente oregunta
    void Start()
    {
        //adquirimos el componente texto de la opcion y sera igual al nombre del scriptableobject
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    //actualiza el texto
    public void Updatetext()
    {
        //actuañiza el texto conforme vaya pasando las preguntas
        transform.GetChild(0).GetComponent <TMP_Text>().text = OptionName;
    }

    //aqui revisa si se ha seleccionado algo en la interfaz 
    public void SelectOptions()
    {
        //asignamos la respuesta correcta del id 
        LevelManager.Instance.SetPlayerAnswer(OptionID);
        //si selecciona una respuesta y revisa si los botones son interactuables
        LevelManager.Instance.CheckPlayerState();
    }

}
