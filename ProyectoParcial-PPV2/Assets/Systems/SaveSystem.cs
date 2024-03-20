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
        if (instance != null)
        {
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
        SaveToJSON("LeccionDummy", data);
        Subject = LoadFromJSON<SubjectContainer>("SubjectDummy");
    }

    public void SaveToJSON(string _fileName, object _data)
    {
        if (_data != null)
        {
            string JSONData = JsonUtility.ToJson(_data);
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
        T Dato = new T();
        string path = Application.dataPath + "/RESOURCES/JSONS" + _fileNmae + "json";
        string JSONData = "";
        if (File.Exists(path))
        {
            JSONData = File.ReadAllText(path);
            Debug.Log("JSON String:" + JSONData);
        }
        if (JSONData.Length != 0)
        {
            JsonUtility.FromJsonOverwrite(JSONData, Dato);
        }
        else
        {
            Debug.LogWarning("ERROR: data is null, is empty, check for param [object data]");

        }
        return Dato;
    }
}
