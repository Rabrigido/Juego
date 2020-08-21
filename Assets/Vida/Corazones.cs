using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazones : MonoBehaviour
{

    public GameObject corazon;
    public GameObject corazon1;
    public GameObject corazon2;
    public GameObject corazon3;
    public int vida = 4;
    public GameObject player;
    public GameObject imagenMuerte;
    public GameObject textoMuerte;
    public GameObject botonMuerteMenu;
    public GameObject botonMuerteContinuar;


    // Start is called before the first frame update
    void Start()
    {
        imagenMuerte.SetActive(false);
        textoMuerte.SetActive(false);
        botonMuerteMenu.SetActive(false);
        botonMuerteContinuar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Vida") == 3)
        {
            corazon.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Vida") == 2)
        {
            corazon.SetActive(false);
            corazon1.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Vida") == 1)
        {
            corazon.SetActive(false);
            corazon1.SetActive(false);
            corazon2.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Vida") == 0)
        {
            corazon.SetActive(false);
            corazon1.SetActive(false);
            corazon2.SetActive(false);
            corazon3.SetActive(false);
            imagenMuerte.SetActive(true);
            textoMuerte.SetActive(true);

            if (PlayerPrefs.GetInt("NumeroJugadores") == 2) 
            {
                if (PlayerPrefs.GetInt("PlayerActual") == 1) 
                {
                    botonMuerteMenu.SetActive(true);
                    botonMuerteContinuar.SetActive(true);
                }
                if (PlayerPrefs.GetInt("PlayerActual") == 2)
                {
                    botonMuerteMenu.SetActive(true);
                }

            }

            if (PlayerPrefs.GetInt("NumeroJugadores") == 1)
            {
                botonMuerteMenu.SetActive(true);
            }
        }
    }
}