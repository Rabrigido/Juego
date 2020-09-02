using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopTen : MonoBehaviour
{
    public GameObject texto;
    // Start is called before the first frame update
    void Start()
    {
        /*
        PlayerPrefs.SetString("DatosNombres", "");
        PlayerPrefs.SetString("DatosPuntajes", "");
        */

        /*Debug.Log(PlayerPrefs.GetString("DatosNombres"));
        Debug.Log(PlayerPrefs.GetString("DatosPuntajes"));*/
        string nombreAux = PlayerPrefs.GetString("DatosNombres");
        string puntajesAux = PlayerPrefs.GetString("DatosPuntajes");
        string[] nombres = nombreAux.Split(',');
        string[] puntajesAuxx = puntajesAux.Split(',');

        int[] puntajes = new int[puntajesAuxx.Length];

        if (puntajesAux.Length > 0)
        {


            for (int i = 0; i < nombres.Length; i++)
            {
                puntajes[i] = int.Parse(puntajesAuxx[i]);
            }

            int aux;
            string aux2;
            if (nombres.Length > 1)
            {
                for (int i = 1; i < nombres.Length; i++)
                {
                    for (int j = nombres.Length - 1; j >= i; j--)
                    {
                        if (puntajes[j - 1] < puntajes[j])
                        {
                            aux = puntajes[j - 1];
                            puntajes[j - 1] = puntajes[j];
                            puntajes[j] = aux;

                            aux2 = nombres[j - 1];
                            nombres[j - 1] = nombres[j];
                            nombres[j] = aux2;
                        }
                    }
                }
            }
           







            if (puntajes.Length >= 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    texto.GetComponent<Text>().text = texto.GetComponent<Text>().text + (i + 1) + ". " + nombres[i] + ": " + puntajes[i] + "\n";
                }
            }
            else
            {
                for (int i = 0; i < puntajes.Length; i++)
                {
                    texto.GetComponent<Text>().text = texto.GetComponent<Text>().text + (i + 1) + ". " + nombres[i] + ": " + puntajes[i] + "\n";
                }
            }
        }
        else
        {
            texto.GetComponent<Text>().text = "No hay jugadores registrados.";
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
