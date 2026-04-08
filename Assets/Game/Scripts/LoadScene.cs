using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

    }

    public void CargarNivel(string sceneName)
    {
        
        string escenaActual = SceneManager.GetActiveScene().name;


        if (escenaActual == "Menu" || sceneName == "Menu" || escenaActual == "Nivel_2")
        {
           

            SceneManager.LoadScene(sceneName);
            return;
        }

        
        if (GameManager.Instance.SeCompletaronLasFrutas())
        {

            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("Faltan frutas por recojer");
        }
    }
}
