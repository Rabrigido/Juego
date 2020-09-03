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
    public GameObject cero;
    public GameObject uno;
    public GameObject dos;
    public GameObject tres;
    public GameObject cuatro;


    private float cont;
    
    


    // Start is called before the first frame update
    void Start()
    {
        imagenMuerte.SetActive(false);
        textoMuerte.SetActive(false);
        botonMuerteMenu.SetActive(false);
        botonMuerteContinuar.SetActive(false);


        cont = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Vida") == 4)
        {
            corazon.SetActive(true);
            corazon1.SetActive(true);
            corazon2.SetActive(true);
            corazon3.SetActive(true);
            cero.SetActive(false);
            uno.SetActive(false);
            dos.SetActive(false);
            tres.SetActive(false);
            cuatro.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Vida") == 3)
        {
            corazon.SetActive(false);
            corazon1.SetActive(true);
            corazon2.SetActive(true);
            corazon3.SetActive(true);
            cero.SetActive(false);
            uno.SetActive(false);
            dos.SetActive(false);
            tres.SetActive(true);
            cuatro.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Vida") == 2)
        {
            corazon.SetActive(false);
            corazon1.SetActive(false);
            corazon2.SetActive(true);
            corazon3.SetActive(true);
            cero.SetActive(false);
            uno.SetActive(false);
            dos.SetActive(true);
            tres.SetActive(false);
            cuatro.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Vida") == 1)
        {
            corazon.SetActive(false);
            corazon1.SetActive(false);
            corazon2.SetActive(false);
            corazon3.SetActive(true);
            cero.SetActive(false);
            uno.SetActive(true);
            dos.SetActive(false);
            tres.SetActive(false);
            cuatro.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Vida") == 0)
        {
            cont = cont + Time.deltaTime;
            PlayerPrefs.SetInt("EstadoMuerto", 1);
            corazon.SetActive(false);
            corazon1.SetActive(false);
            corazon2.SetActive(false);
            corazon3.SetActive(false);

            cero.SetActive(true);
            uno.SetActive(false);
            dos.SetActive(false);
            tres.SetActive(false);
            cuatro.SetActive(false);

            if (cont > 1)
            {
                if (PlayerPrefs.GetInt("NumeroJugadores") == 2)
                {
                    if (PlayerPrefs.GetInt("PlayerActual") == 1)
                    {
                        botonMuerteMenu.SetActive(true);
                        botonMuerteContinuar.SetActive(true);
                        Time.timeScale = 0;
                    }
                    if (PlayerPrefs.GetInt("PlayerActual") == 2)
                    {
                        botonMuerteMenu.SetActive(true);
                        Time.timeScale = 0;
                    }
                }
                if (PlayerPrefs.GetInt("NumeroJugadores") == 1)
                {
                    botonMuerteMenu.SetActive(true);
                    Time.timeScale = 0;
                }
            }
            imagenMuerte.SetActive(true);
            textoMuerte.SetActive(true);
        }
    }
}