using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GuardarPuntajes : MonoBehaviour

{
    public InputField Entrada1;

    private string nombre1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ok()
    {

        nombre1 = Entrada1.text;

        if (nombre1 != null && nombre1 != "")
        {
            string texto = nombre1 + "," + PlayerPrefs.GetInt("PuntajeTotal");
            File.AppendAllLines("DatosJugadores.txt", new string[] { texto });

            if (PlayerPrefs.GetInt("NumeroJugadores") == 1 && PlayerPrefs.GetInt("Vida") > 0)
            {
                SceneManager.LoadScene("Creditos", LoadSceneMode.Single);
            }
            else if(PlayerPrefs.GetInt("NumeroJugadores") == 1 && PlayerPrefs.GetInt("Vida") <= 0)
            {
                SceneManager.LoadScene("MenuPrincipal", LoadSceneMode.Single);
            }
            else if(PlayerPrefs.GetInt("NumeroJugadores") == 2 && PlayerPrefs.GetInt("Vida") > 0)
            {
                if(PlayerPrefs.GetInt("PlayerActual") == 1)
                {
                    PlayerPrefs.SetInt("PlayerActual", 2);
                    PlayerPrefs.SetInt("Vida", 4);
                    SceneManager.LoadScene("cargaMenuN1.1");
                }
                else
                {
                    SceneManager.LoadScene("Creditos", LoadSceneMode.Single);
                }
            }
            else if(PlayerPrefs.GetInt("NumeroJugadores") == 2 && PlayerPrefs.GetInt("Vida") <= 0)
            {
                if (PlayerPrefs.GetInt("PlayerActual") == 1)
                {
                    PlayerPrefs.SetInt("PlayerActual", 2);
                    PlayerPrefs.SetInt("Vida", 4);
                    SceneManager.LoadScene("cargaMenuN1.1");
                }
                else
                {
                    SceneManager.LoadScene("MenuPrincipal", LoadSceneMode.Single);
                }
            }

        }   


    }
}

