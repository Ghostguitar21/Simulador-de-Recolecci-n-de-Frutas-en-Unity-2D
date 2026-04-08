using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Collections;

using static LeerJS;

public class Controller_Nivel_2 : MonoBehaviour

{

    public TextMeshProUGUI Mision;
    private LeerJS.mision misionActual;
    public GameObject fin;
    private bool misionCompletada = false;

    void Start()
    {
        LeerJS lector = GameManager.Instance?.leerJS;

        if (lector != null && lector.listaMisiones.Count > 0)
        {
            
            int indice = Random.Range(0, lector.listaMisiones.Count);
            misionActual = lector.listaMisiones[indice];

            
            Spawner spawner = FindFirstObjectByType<Spawner>();
            if (spawner != null)
                spawner.Crear(4, misionActual.objetivos);

            LoadMission(misionActual);

            
        }
        fin.SetActive(false);
    }


    void Update()
    {
        if (!misionCompletada && misionActual != null && ValidarMision())
        {
            misionCompletada = true;
            MostrarVictoria();
        }
    }

    bool ValidarMision()
    {
        var recogidos = GameManager.Instance.itemsRecogidos;

        foreach (var objetivo in misionActual.objetivos)
        {
            if (!recogidos.ContainsKey(objetivo.itemName) ||
                 recogidos[objetivo.itemName] < objetivo.cantidad)
            {
                return false;
            }
        }
        return true;
    }

    void MostrarVictoria()
    {
        Mision.text = "¡Misión completada!";
        Debug.Log("¡Victoria!");
        fin.SetActive(true);

    }

    

    public void LoadMission(mision data)
    {
        string textoMision = $"Misión {data.id}: {data.titulo}\n";
        textoMision += "Objetivos:\n";


        if (data.objetivos != null && data.objetivos.Count > 0)
        {
            foreach (var obj in data.objetivos)
            {
                textoMision += $"- {obj.itemName}: {obj.cantidad}\n";
            }
        }
        else
        {
            textoMision += "Sin objetivos definidos.\n";
        }
        Mision.text = textoMision;
    }

        
   
   
}


