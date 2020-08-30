using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour
{
    // Start is called before the first frame update

    public int tiempoInicial; //tiempo inicial en segundos

    public float escalaDeTiempo = 1;

    private Text textoTiempo;
    private float tiempoAMostrarEnSegundos = 0f;

    private float escalaDeTiempoAlPausar;

    private float escalaDeTiempoAlIniciar;
    private Boolean estaPausado;


    void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("Nivel1.1"))
        {
            PlayerPrefs.SetFloat("Tiempo", 0f);
        }
        /*else
        {
            PlayerPrefs.SetFloat("Tiempo", 0f);
        }
        */

        textoTiempo = GetComponent<Text>();

        ActualizarReloj(PlayerPrefs.GetFloat("Tiempo"));
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("Tiempo", PlayerPrefs.GetFloat("Tiempo") + Time.deltaTime);
        ActualizarReloj(PlayerPrefs.GetFloat("Tiempo"));
    }

    public void ActualizarReloj(float tiempoEnSegundos)

    {
        int minutos = 0;
        int segundos = 0;
        int milisegundos = 0;
        string textoDelReloj;

        if (tiempoEnSegundos < 0) tiempoEnSegundos = 0;

        minutos = (int)tiempoEnSegundos / 60;
        segundos = (int)tiempoEnSegundos % 60;
        milisegundos = (int)(((tiempoEnSegundos % 60) - segundos) * 60);

        textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00") + ":" + milisegundos.ToString("00");
        textoTiempo.text = textoDelReloj;
    }
}
