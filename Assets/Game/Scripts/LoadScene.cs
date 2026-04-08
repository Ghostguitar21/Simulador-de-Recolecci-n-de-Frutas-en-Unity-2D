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
        SceneManager.LoadScene(sceneName);
    }

    
}
