using UnityEngine;
using static LeerJS;

public class Spawner : MonoBehaviour
{

    public GameObject Fruta;

    void Start()
    {
        Crear();
    }

    public void Crear()
    {
        foreach (coleccionable dato in LeerJS.listaColeccionables) 
        {
            Vector3 posicion = new Vector3(Random.Range(-5, 5), Random.Range(-3, 3), 0);
            GameObject nuevoObjeto = Instantiate(Fruta, posicion, Quaternion.identity);
            InstanciaFruta datosDinamicos = ScriptableObject.CreateInstance<InstanciaFruta>();
            datosDinamicos.Setup(dato);


            if (nuevoObjeto.TryGetComponent(out ItemRecolectable scriptRecoleccion))
            {
                scriptRecoleccion.Inicio(datosDinamicos);
            }
        }
    }
}
