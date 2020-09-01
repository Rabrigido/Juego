using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Jugadores : MonoBehaviour
{
    public InputField Entrada;
    public Text Salida;
    private Boolean error = false;
    private string id;
    private ArrayList ids;
    private ArrayList puntajes;
    // Start is called before the first frame update
    void Start()
    {

        ids = new ArrayList();
        puntajes = new ArrayList();

        string[] lines = System.IO.File.ReadAllLines("DatosJugadores.txt");

        foreach (string line in lines)
        {
            string[] linea = line.Split(',');

            ids.Add(linea[0]);
            puntajes.Add(linea[1]);

        }

       


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void lectura()
    {

        

        
    }
}
