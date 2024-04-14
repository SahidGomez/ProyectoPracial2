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
            //Si no existe una instancia, asigna la instancia a instance.
            instance = this;
        }
        //La cadena JSON se almacena en "SelectedLesson"
        Subject = LoadFromJSON<SubjectContainer>(PlayerPrefs.GetString("SelectedLesson"));

    }

    //<summary>
    //Funcion encargada de almacenar objetos de archivos JSON
    //<paran  

    private void Start()
    {
        //Guarda datos desde un archivo JSON
        //Guarda los datos de la variable data
        //SaveToJSON("LeccionDummy", data);
        //Carga los datos del archivo JSON "SubjectDummy" en la variable Subject
        
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
                //verifica el nombre del archivo con la extensión .json.
                string fileName = _fileName + ".json";
                //Combina la carpeta Resources con el nombre del archivo.
                string filePath = Path.Combine(Application.dataPath + "/RESOURCES/JSONS", fileName);
                //Escribe el JSON en el archivo 
                File.WriteAllText(filePath, JSONData);
                //Muestra un mensaje en consola indicando la ubicación del archivo
                Debug.Log("JSON almacenado en la direccion: " + filePath);
            }
            else
            {
                Debug.LogWarning("ERROR: data is null, is empty, check for param [object data]");
            }
        }
        else
        {
            //Muestra una advertencia si JSONData es nulo o está vacío.
            Debug.LogWarning("ERROR: data is null, check for param [object data]");
        }
    }

    public T LoadFromJSON<T>(string _fileNmae) where T : new()
    {
        //Crea una nueva instancia de tipo T
        T Dato = new T();
        string path = Application.dataPath + "/RESOURCES/JSONS/" + _fileNmae + ".json";
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
