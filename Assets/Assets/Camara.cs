﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject personaje;
    private Vector3 posicion;

    // Start is called before the first frame update
    void Start()
    {
        posicion = transform.position - personaje.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = personaje.transform.position + posicion;
    }
}