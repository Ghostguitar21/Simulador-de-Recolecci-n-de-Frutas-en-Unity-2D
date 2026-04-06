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

    public void Crear(int cantidad = 4)
    {
        for (int i = 0; i < cantidad; i++)
        {
            // 1. Elegir coleccionable aleatorio del JSON
            int indice = Random.Range(0, LeerJS.listaColeccionables.Count);
            coleccionable datos = LeerJS.listaColeccionables[indice];

            // 2. Crear InstanciaFruta en runtime (NO es GetComponent, es ScriptableObject)
            InstanciaFruta instancia = ScriptableObject.CreateInstance<InstanciaFruta>();
            instancia.Setup(datos);

            // 3. Spawn en punto aleatorio
            Transform punto = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject nuevo = Instantiate(FrutaPrefab, punto.position, Quaternion.identity);

            // 4. Pasar datos al componente del prefab genérico
            ItemRecolectable item = nuevo.GetComponent<ItemRecolectable>();
            if (item != null)
                item.Inicio(instancia);
        }
    }
}
