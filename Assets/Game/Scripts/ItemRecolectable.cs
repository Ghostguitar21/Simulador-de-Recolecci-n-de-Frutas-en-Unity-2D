using NUnit.Framework.Interfaces;
using UnityEngine;


public class ItemRecolectable : MonoBehaviour
{
    [SerializeField] private InstanciaFruta datosFruta;
    private SpriteRenderer sRenderer;

    void Awake() => sRenderer = GetComponent<SpriteRenderer>();

    public void Inicio(InstanciaFruta nuevosDatos)
    {
        datosFruta = nuevosDatos;
        sRenderer.sprite = datosFruta.visualF;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.TotalItem(datosFruta);
            Debug.Log("Recolectado" + datosFruta);
            Destroy(gameObject);
        }
    }
}
