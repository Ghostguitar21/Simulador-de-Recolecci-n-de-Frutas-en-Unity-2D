using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Collections;

using static LeerJS;

public class Controller_Nivel_2 : MonoBehaviour

{

    public TextMeshProUGUI Mision;
    private LeerJS.mision misionActual;

    void Start()
    {

        LeerJS lector = GameManager.Instance?.leerJS;


        if (lector != null && lector.listaMisiones.Count > 0)
        {
            int indiceAleatorio = Random.Range(0, lector.listaMisiones.Count);
            LoadMission(lector.listaMisiones[indiceAleatorio]);
            LoadMission(misionActual);
        }
        else
        {
            Debug.LogWarning("No se encontró LeerJS o la lista de misiones está vacía.");
        }
       
    }


    void Update()
    {
        if (misionActual != null && ValidarMision())
        {
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


