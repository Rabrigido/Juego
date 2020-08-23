using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contadordecarpetas : MonoBehaviour
{
    public GameObject texto;
    public int contador = 0;
    public int total = 0;

    public GameObject ceroizq;
    public GameObject unoizq;
    public GameObject dosizq;
    public GameObject tresizq;
    public GameObject cuatroizq;
    public GameObject cincoizq;
    public GameObject ceroder;
    public GameObject unoder;
    public GameObject dosder;
    public GameObject tresder;
    public GameObject cuatroder;
    public GameObject cincoder;
    // Start is called before the first frame update
    void Start()
    {
        texto.GetComponent<Text>().text = contador.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        contador = Int32.Parse(texto.GetComponent<Text>().text);
        if (contador == 0)
        {
            ceroizq.SetActive(true);
            unoizq.SetActive(false);
            dosizq.SetActive(false);
            tresizq.SetActive(false);
            cuatroizq.SetActive(false);
            cincoizq.SetActive(false);
        }
        if (contador == 1)
        {
            ceroizq.SetActive(false);
            unoizq.SetActive(true);
            dosizq.SetActive(false);
            tresizq.SetActive(false);
            cuatroizq.SetActive(false);
            cincoizq.SetActive(false);
        }
        if (contador == 2)
        {
            ceroizq.SetActive(false);
            unoizq.SetActive(false);
            dosizq.SetActive(true);
            tresizq.SetActive(false);
            cuatroizq.SetActive(false);
            cincoizq.SetActive(false);
        }
        if (contador == 3)
        {
            ceroizq.SetActive(false);
            unoizq.SetActive(false);
            dosizq.SetActive(false);
            tresizq.SetActive(true);
            cuatroizq.SetActive(false);
            cincoizq.SetActive(false);
        }
        if (contador == 4)
        {
            ceroizq.SetActive(false);
            unoizq.SetActive(false);
            dosizq.SetActive(false);
            tresizq.SetActive(false);
            cuatroizq.SetActive(true);
            cincoizq.SetActive(false);
        }
        if (contador == 5)
        {
            ceroizq.SetActive(false);
            unoizq.SetActive(false);
            dosizq.SetActive(false);
            tresizq.SetActive(false);
            cuatroizq.SetActive(false);
            cincoizq.SetActive(true);
        }


        if (total == 0)
        {
            ceroder.SetActive(true);
            unoder.SetActive(false);
            dosder.SetActive(false);
            tresder.SetActive(false);
            cuatroder.SetActive(false);
            cincoder.SetActive(false);
        }
        if (total == 1)
        {
            ceroder.SetActive(false);
            unoder.SetActive(true);
            dosder.SetActive(false);
            tresder.SetActive(false);
            cuatroder.SetActive(false);
            cincoder.SetActive(false);
        }
        if (total == 2)
        {
            ceroder.SetActive(false);
            unoder.SetActive(false);
            dosder.SetActive(true);
            tresder.SetActive(false);
            cuatroder.SetActive(false);
            cincoder.SetActive(false);
        }
        if (total == 3)
        {
            ceroder.SetActive(false);
            unoder.SetActive(false);
            dosder.SetActive(false);
            tresder.SetActive(true);
            cuatroder.SetActive(false);
            cincoder.SetActive(false);
        }
        if (total == 4)
        {
            ceroder.SetActive(false);
            unoder.SetActive(false);
            dosder.SetActive(false);
            tresder.SetActive(false);
            cuatroder.SetActive(true);
            cincoder.SetActive(false);
        }
        if (total == 5)
        {
            ceroder.SetActive(false);
            unoder.SetActive(false);
            dosder.SetActive(false);
            tresder.SetActive(false);
            cuatroder.SetActive(false);
            cincoder.SetActive(true);
        }
    }
}
