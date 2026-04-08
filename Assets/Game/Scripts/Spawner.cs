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
        Crear();
    }

    public void Crear(int cantidad = 4, List<ObjetivoMision> objetivos = null)
    {
        
        puntosDisponibles = new List<Transform>(spawnPoints);

        if (objetivos != null)
        {
            foreach (var objetivo in objetivos)
            {
                for (int i = 0; i < objetivo.cantidad; i++)
                {
                    if (puntosDisponibles.Count == 0) break;

                    coleccionable datos = listaColeccionables
                        .Find(c => c.nombre == objetivo.itemName);

                    if (datos != null)
                        SpawnFruta(datos);
                }
            }
        }

        
        int restantes = cantidad - (spawnPoints.Length - puntosDisponibles.Count);
        for (int i = 0; i < restantes; i++)
        {
            if (puntosDisponibles.Count == 0) break;

            int indiceFruta = Random.Range(0, listaColeccionables.Count);
            SpawnFruta(listaColeccionables[indiceFruta]);
        }
    }
    void SpawnFruta(coleccionable datos)
    {
        int indicePunto = Random.Range(0, puntosDisponibles.Count);
        Transform puntoSeleccionado = puntosDisponibles[indicePunto];

        InstanciaFruta instancia = ScriptableObject.CreateInstance<InstanciaFruta>();
        instancia.Setup(datos);

        GameObject nuevo = Instantiate(FrutaPrefab, puntoSeleccionado.position, Quaternion.identity);
        ItemRecolectable item = nuevo.GetComponent<ItemRecolectable>();
        if (item != null)
            item.Inicio(instancia);

        puntosDisponibles.RemoveAt(indicePunto);
    }
}

