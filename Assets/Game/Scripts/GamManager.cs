using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GamManager : MonoBehaviour
{

    public static GamManager Instance;


    private void Awake()
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
        
    }

    
    void Update()
    {
        
    }
}
