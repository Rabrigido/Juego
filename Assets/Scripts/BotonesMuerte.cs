﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesMuerte : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void continuar()
    {
        /**/
        SceneManager.LoadScene("Nivel6.1");
    }

    public void volverMenu()
    {
        SceneManager.LoadScene("MenuPrincipal"); //Escena de carga <-
    }

}
