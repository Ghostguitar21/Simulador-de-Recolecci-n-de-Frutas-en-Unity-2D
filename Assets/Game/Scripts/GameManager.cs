using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using static LeerJS;
public class GameManager : MonoBehaviour
{

    public GameObject Tutorial;
    public static GameManager Instance;
    public LeerJS leerJS;
    
    
    

    void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }



    void Start()
    {
        Tutorial.SetActive(false);
        
        Debug.Log(leerJS.listaColeccionables.Count);
    }

    void Update()
    {
        
    }

    public void LoadTutorial()
    {
        Tutorial.SetActive(true);
    }

    public void CerrarTutorial()
    {
        Tutorial.SetActive(false);
    }

   

}
