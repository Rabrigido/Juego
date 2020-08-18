﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyLife : MonoBehaviour
{

    public int cantidadBalas;
    public GameObject textoContadorEnemigos;
    private int contador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cantidadBalas == 0)
        {
            Destroy(gameObject);
            contador = Int32.Parse(textoContadorEnemigos.GetComponent<Text>().text);
            contador--;
            textoContadorEnemigos.GetComponent<Text>().text = contador.ToString();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.gameObject.tag == "Bala")
        {
            cantidadBalas--;
        }
    }
}
