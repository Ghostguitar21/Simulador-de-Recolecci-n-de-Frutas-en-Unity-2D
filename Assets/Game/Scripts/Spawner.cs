//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using static LeerJS;

//public class Spawner : MonoBehaviour
//{

//    public GameObject coleccionable;
//    public Transform[] spawnPoints;

//    void Start()
//    {
//        SpawnItems();
//    }

//    public void SpawnItems(int cantidad = 4)
//    {

//        for (int i = 0; i < cantidad; i++)
//        {
//            LeerJS dataManager = FindFirstObjectByType<LeerJS>();
//            int indiceAleatorio = Random.Range(0, spawnPoints.Length);
//            Transform punto = spawnPoints[indiceAleatorio];
//            GameObject nuevoItem = Instantiate(coleccionable, punto.position, Quaternion.identity);

//            if (dataManager != null && dataManager.listaColeccionables.Count > 0)
//            {
//                int puntoRandom = Random.Range(0, dataManager.listaColeccionables.Count);
//                var infoJson = dataManager.listaColeccionables[puntoRandom];


//                nuevoItem.GetComponent<InstanciaFruta>().Setup(infoJson);


//                InstanciaFruta scriptFruta = nuevoItem.GetComponent<InstanciaFruta>();
//                if (scriptFruta != null)
//                {
//                    scriptFruta.Setup(infoJson);
//                }

//            }


//        }
//    }
//}
