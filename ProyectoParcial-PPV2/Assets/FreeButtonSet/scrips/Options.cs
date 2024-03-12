using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class Options : MonoBehaviour
{
    public int OptionID;
    public string OptionName;
    // Start is called before the first frame update
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

    public void SelectOptions()
    {
        //mandamos el contenido de Iption al setPlayer answer
        LevelManager.Instance.SetPlayerAnswer(OptionID);
        //
        LevelManager.Instance.CheckPlayerState();
    }

}
