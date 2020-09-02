using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GuardarPuntajes : MonoBehaviour

{
    public InputField Entrada1;
    private Boolean Aviso;
    public GameObject ventanaAviso;
    

    private string nombre1;

    // Start is called before the first frame update
    void Start()
    {
        
        Time.timeScale = 1;
        PlayerPrefs.SetInt("EstadoMuerto", 0);
        Aviso = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Aviso)
        {
            ventanaAviso.SetActive(true);
        }
        else
        {
            ventanaAviso.SetActive(false);
        }
    }

    public void ok()
    {

        nombre1 = Entrada1.text;

        if (nombre1 != null && nombre1 != "" && !nombre1.Contains(",") && nombre1.Length <= 20 )
        {
            Aviso = false;
            string texto = nombre1 + "," + PlayerPrefs.GetInt("PuntajeTotal");
            
            if (PlayerPrefs.GetString("DatosNombres") == "")
            {
                string ptje = PlayerPrefs.GetInt("PuntajeTotal").ToString();
                PlayerPrefs.SetString("DatosNombres", nombre1);
                PlayerPrefs.SetString("DatosPuntajes", ptje);
            }
            else
            {
                PlayerPrefs.SetString("DatosNombres", PlayerPrefs.GetString("DatosNombres") + "," + nombre1);
                PlayerPrefs.SetString("DatosPuntajes", PlayerPrefs.GetString("DatosPuntajes") + "," + PlayerPrefs.GetInt("PuntajeTotal"));
            }
            

            if (PlayerPrefs.GetInt("NumeroJugadores") == 1 && PlayerPrefs.GetInt("Vida") > 0)
            { //Modo 1 player y ganó
                SceneManager.LoadScene("Creditos", LoadSceneMode.Single);
            }
            else if(PlayerPrefs.GetInt("NumeroJugadores") == 1 && PlayerPrefs.GetInt("Vida") <= 0)
            { //Modo 1 player y perdió
                SceneManager.LoadScene("MenuPrincipal", LoadSceneMode.Single);
            }
            else if(PlayerPrefs.GetInt("NumeroJugadores") == 2 && PlayerPrefs.GetInt("Vida") > 0)
            { //Modo 2 player y alguno ganó
                if(PlayerPrefs.GetInt("PlayerActual") == 1) //Si gana el player 1
                {
                    PlayerPrefs.SetInt("PlayerActual", 2);
                    //PlayerPrefs.SetInt("Vida", 4);
                    SceneManager.LoadScene("cargaMenuN1.1"); //Sigue el 2
                }
                else //Si gana el player 2
                {
                    SceneManager.LoadScene("Creditos", LoadSceneMode.Single); //Creditos para ambos
                }
            }
            else if(PlayerPrefs.GetInt("NumeroJugadores") == 2 && PlayerPrefs.GetInt("Vida") <= 0)
            {//Modo 2 player y alguno perdió
                if (PlayerPrefs.GetInt("PlayerActual") == 1)//Si pierde el 1
                {
                    PlayerPrefs.SetInt("PlayerActual", 2);
                    //PlayerPrefs.SetInt("Vida", 4);
                    SceneManager.LoadScene("cargaMenuN1.1"); //Sigue el 2
                }
                else //Perdió el segundo
                {
                    SceneManager.LoadScene("MenuPrincipal", LoadSceneMode.Single); //Menú principal
                }
            }

        }
        else //Si esta malo el nombre
        {
            Aviso = true;
        }




    }
}

