using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class LeerJS : MonoBehaviour
{
    public TextAsset Info;

    [System.Serializable]
    public class coleccionable
    {
        public string nombre;
        public string rareza;
        public int valor;
        public string iconoId;
    }
    [System.Serializable]
    public class mision
    {
        public int id;
        public string titulo;
        public List<ObjetivoMision> objetivos = new List<ObjetivoMision>();

    }
    [System.Serializable]
    public class ObjetivoMision
    {
        public string itemName; 
        public int cantidad;    
    }



    [System.Serializable]
    public class DataMaestra
    {
        public coleccionable[] coleccionables;
        public mision[] misiones;
    }

    public DataMaestra DatosCargados;

    public static List<coleccionable> listaColeccionables = new List<coleccionable>();
    public List<mision> listaMisiones = new List<mision>();


    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, "Info.json");
        string json = System.IO.File.ReadAllText(path);
        DatosCargados = JsonUtility.FromJson<DataMaestra>(json);

        listaColeccionables = new List<coleccionable>(DatosCargados.coleccionables);
        listaMisiones = new List<mision>(DatosCargados.misiones);
    }
}
