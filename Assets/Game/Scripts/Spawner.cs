using NUnit.Framework.Interfaces;
using UnityEditor;
using UnityEngine;
using static LeerJS;

public class Spawner : MonoBehaviour
{

    public GameObject FrutaPrefab;
    public Transform[] spawnPoints;



    void Start()
    {
        Crear(4);
    }

    public void Crear(int cantidad =4)
    {
        for (int i = 0; i < cantidad; i++)
        {
            // Seleccionar un coleccionable aleatorio de la lista
            int indiceColeccionable = Random.Range(0, LeerJS.listaColeccionables.Count);
            LeerJS.coleccionable coleccionableSeleccionado = LeerJS.listaColeccionables[indiceColeccionable];

            // Seleccionar un punto de spawn aleatorio
            int indiceAleatorio = Random.Range(0, spawnPoints.Length);
            Transform punto = spawnPoints[indiceAleatorio];

            // Crear la fruta
            GameObject nuevoItem = Instantiate(FrutaPrefab, punto.position, Quaternion.identity);

            // Opcional: Asignar datos del coleccionable al objeto instanciado
            InstanciaFruta itemData = nuevoItem.GetComponent<InstanciaFruta>();
            if (itemData != null)
            {
                itemData.Setup(coleccionableSeleccionado);
            }
        }
    }
}
