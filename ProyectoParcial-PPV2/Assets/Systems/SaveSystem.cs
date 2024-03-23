using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;

    public Leccion1 data;
    public SubjectContainer Subject;



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

    //<summary>
    //Funcion encargada de almacenar objetos de archivos JSON
    //<paran  

    private void Start()
    {
        //Guarda datos desde un archivo JSON
        //Guarda los datos de la variable data
        SaveToJSON("LeccionDummy", data);
        //Carga los datos del archivo JSON "SubjectDummy" en la variable Subject
        Subject = LoadFromJSON<SubjectContainer>("SubjectDummy");
    }

    //Función para guardar datos en un archivo JSON
    public void SaveToJSON(string _fileName, object _data)
    {
        if (_data != null)
        {
            //Convierte los datos a JSON
            string JSONData = JsonUtility.ToJson(_data);
            //Comprueba si la cadena JSON no está vacía
            if (JSONData.Length != 0)
            {
                Debug.Log("JSON STRING: " + JSONData);
                string fileName = _fileName + ".json";
                string filePath = Path.Combine(Application.dataPath + "/RESOURCES/JSONS", fileName);
                File.WriteAllText(filePath, JSONData);
                Debug.Log("JSON almacenado en la direccion: " + filePath);
            }
            else
            {
                Debug.LogWarning("ERROR: data is null, is empty, check for param [object data]");
            }
        }
        else
        {
            Debug.LogWarning("ERROR: data is null, check for param [object data]");
        }
    }

    public T LoadFromJSON<T>(string _fileNmae) where T : new()
    {
        //Crea una nueva instancia de tipo T
        T Dato = new T();
        string path = Application.dataPath + "/RESOURCES/JSONS" + _fileNmae + "json";
        string JSONData = "";
        //Comprueba si el archivo JSON existe
        if (File.Exists(path))
        {
            //Lee el contenido del archivo JSON
            JSONData = File.ReadAllText(path);
            Debug.Log("JSON String:" + JSONData);
        }
        //Comprueba si la cadena JSON está vacía o no
        if (JSONData.Length != 0)
        {
            JsonUtility.FromJsonOverwrite(JSONData, Dato);
        }
        else
        {
            Debug.LogWarning("ERROR: data is null, is empty, check for param [object data]");

        }
        //Devuelve los datos cargados desde el archivo JSON
        return Dato;
    }
}
