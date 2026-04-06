using UnityEngine;
using static LeerJS;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]


public class InstanciaFruta : ScriptableObject
{
    public string nombreF;
    public string rarezaF;
    public int valorF;
    public string iconoIdF;
    public Sprite visualF;

    public void Setup(coleccionable data)
    {
        nombreF = data.nombre;
        rarezaF = data.rareza;
        valorF = data.valor;
        iconoIdF = data.iconoId;


        Sprite loadedSprite = Resources.Load<Sprite>(data.iconoId);
        if (loadedSprite != null)
        {
            visualF = Resources.Load<Sprite>(data.iconoId);
        }

        Sprite[] frames = Resources.LoadAll<Sprite>(data.iconoId);
        Debug.Log($"Cargando: {data.iconoId} → frames encontrados: {frames.Length}");
        if (frames.Length > 0)
            visualF = frames[0];


    }

   

    
}
    