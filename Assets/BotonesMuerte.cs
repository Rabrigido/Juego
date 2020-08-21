using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        PlayerPrefs.SetInt("PlayerActual",2);
        PlayerPrefs.SetInt("Vida", 4);
        SceneManager.LoadScene("Nivel2.1");
    }

    public void volverMenu()
    {
        SceneManager.LoadScene("MenuPrincipal"); //Escena de carga <-
    }
}
