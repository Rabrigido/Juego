using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aliens : MonoBehaviour
{
    public GameObject contadorAliens;
    private int contador;
    public GameObject cero;
    public GameObject uno;
    public GameObject dos;
    public GameObject tres;
    public GameObject cuatro;
    public GameObject cinco;
    public GameObject seis;
    public GameObject siete;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contador = Int32.Parse(contadorAliens.GetComponent<Text>().text);
        if (contador == 0)
        {
            cero.SetActive(true);
            uno.SetActive(false);
            dos.SetActive(false);
            tres.SetActive(false);
            cuatro.SetActive(false);
            cinco.SetActive(false);
            seis.SetActive(false);
            siete.SetActive(false);
        }
        if (contador == 1)
        {
            cero.SetActive(false);
            uno.SetActive(true);
            dos.SetActive(false);
            tres.SetActive(false);
            cuatro.SetActive(false);
            cinco.SetActive(false);
            seis.SetActive(false);
            siete.SetActive(false);
        }
        if (contador == 2)
        {
            cero.SetActive(false);
            uno.SetActive(false);
            dos.SetActive(true);
            tres.SetActive(false);
            cuatro.SetActive(false);
            cinco.SetActive(false);
            seis.SetActive(false);
            siete.SetActive(false);
        }
        if (contador == 3)
        {
            cero.SetActive(false);
            uno.SetActive(false);
            dos.SetActive(false);
            tres.SetActive(true);
            cuatro.SetActive(false);
            cinco.SetActive(false);
            seis.SetActive(false);
            siete.SetActive(false);
        }
        if (contador == 4)
        {
            cero.SetActive(false);
            uno.SetActive(false);
            dos.SetActive(false);
            tres.SetActive(false);
            cuatro.SetActive(true);
            cinco.SetActive(false);
            seis.SetActive(false);
            siete.SetActive(false);
        }
        if (contador == 5)
        {
            cero.SetActive(false);
            uno.SetActive(false);
            dos.SetActive(false);
            tres.SetActive(false);
            cuatro.SetActive(false);
            cinco.SetActive(true);
            seis.SetActive(false);
            siete.SetActive(false);
        }
        if (contador == 6)
        {
            cero.SetActive(false);
            uno.SetActive(false);
            dos.SetActive(false);
            tres.SetActive(false);
            cuatro.SetActive(false);
            cinco.SetActive(false);
            seis.SetActive(true);
            siete.SetActive(false);
        }
        if (contador == 7)
        {
            cero.SetActive(false);
            uno.SetActive(false);
            dos.SetActive(false);
            tres.SetActive(false);
            cuatro.SetActive(false);
            cinco.SetActive(false);
            seis.SetActive(false);
            siete.SetActive(true);
        }
    }
}
