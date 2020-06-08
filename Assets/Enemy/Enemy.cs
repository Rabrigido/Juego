﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Media;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Variables para gestionar el radio de vision y velocidad
    public float visionRadius;
    public float speed;
    public int option;
    public GameObject player;

    //Variable para guardar la posicion
    //GameObject player;
    //Variable para guardar la posicion inicial
    Vector3 initialPosition;
    Vector3 target;


    // Start is called before the first frame update
    void Start()
    {   
        //Recuperamos al jugador gracias al tag
        //player = GameObject.FindGameObjectWithTag("Player");

        //Guardamos nuestra posicion inicial
        initialPosition = transform.position;
        target = gameObject.transform.position;
    }
        
    // Update is called once per frame
    void Update()
    {
        

        if (option == 1)
        {
            //Por defecto nuestro objetivo siempre sera nuestra posicion inicial 
            target = initialPosition;
            //Pero si la distancia hasta el jugador es menor que el radio de vision el objetivo sera él
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist < visionRadius) target = player.transform.position;

            //Finalmente movemos el enemigo en direccion a su target
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        }
        else if(option == 2)
        {
            target = transform.position;
            //Pero si la distancia hasta el jugador es menor que el radio de vision el objetivo sera él
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist < visionRadius) target = player.transform.position;

            //Finalmente movemos el enemigo en direccion a su target
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        }
        
    }

    void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, visionRadius);
        }



    
}