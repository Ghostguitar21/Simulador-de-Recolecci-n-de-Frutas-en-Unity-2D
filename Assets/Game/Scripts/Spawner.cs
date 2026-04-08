using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static LeerJS;

public class Spawner : MonoBehaviour
{
    public GameObject FrutaPrefab;
    public Transform[] spawnPoints;

    
    List<Transform> puntosDisponibles;

    void Start()
    {
        Crear(4);
    }

    public void Crear(int cantidad = 4)
    {
        
        puntosDisponibles = new List<Transform>(spawnPoints);

        for (int i = 0; i < cantidad; i++)
        {
            if (puntosDisponibles.Count == 0) break;

            
            int indicePunto = Random.Range(0, puntosDisponibles.Count);
            Transform puntoSeleccionado = puntosDisponibles[indicePunto];

            
            int indiceFruta = Random.Range(0, LeerJS.listaColeccionables.Count);
            coleccionable datos = LeerJS.listaColeccionables[indiceFruta];

            
            InstanciaFruta instancia = ScriptableObject.CreateInstance<InstanciaFruta>();
            instancia.Setup(datos);

            
            GameObject nuevo = Instantiate(FrutaPrefab, puntoSeleccionado.position, Quaternion.identity);

            ItemRecolectable item = nuevo.GetComponent<ItemRecolectable>();
            if (item != null)
                item.Inicio(instancia);

            
            puntosDisponibles.RemoveAt(indicePunto);
        }
    }
}
