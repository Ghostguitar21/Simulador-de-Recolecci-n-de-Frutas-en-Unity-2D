using UnityEngine;
using static LeerJS;

public class InstanciaFruta : MonoBehaviour
{
    public string nombreF;
    public string rarezaF;
    public int valorF;
    public string iconoIdF;
    public SpriteRenderer spriteRenderer;

    public void Setup(coleccionable data)
    {
        nombreF = data.nombre;
        rarezaF = data.rareza;
        valorF = data.valor;
        iconoIdF = data.iconoId;


        Sprite loadedSprite = Resources.Load<Sprite>(data.iconoId);
        if (loadedSprite != null)
        {
            spriteRenderer.sprite = loadedSprite;
        }
    }
}
    