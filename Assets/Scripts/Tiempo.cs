using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour
{
    // Start is called before the first frame update

    public int tiempoInicial; //tiempo inicial en segundos

    public float escalaDeTiempo = 1;

    private Text textoTiempo;
    private float tiempoDelFrameConTimeScale = 0f;
    private float tiempoAMostrarEnSegundos = 0f;

    private float escalaDeTiempoAlPausar;

    private float escalaDeTiempoAlIniciar;
    private Boolean estaPausado;


    void Start()
    {
        textoTiempo = GetComponent<Text>();
        tiempoAMostrarEnSegundos = tiempoInicial;

        ActualizarReloj(tiempoInicial);
    }

    // Update is called once per frame
    void Update()
    {
 
        tiempoAMostrarEnSegundos += Time.deltaTime;
        ActualizarReloj(tiempoAMostrarEnSegundos);
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
