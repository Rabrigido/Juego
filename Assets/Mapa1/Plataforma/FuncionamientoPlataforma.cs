using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class FuncionamientoPlataforma : MonoBehaviour
{
    public Transform PosY;
    public Boolean SobrePlataforma;
    Vector2 tamaño;
    

    // Start is called before the first frame update
    void Start()
    {
        tamaño = gameObject.GetComponent<BoxCollider2D>().size;
        gameObject.GetComponent<BoxCollider2D>().size = gameObject.GetComponent<BoxCollider2D>().size - gameObject.GetComponent<BoxCollider2D>().size;

    }

    // Update is called once per frame
    void Update()
    {
        

        if (PosY.position.y.CompareTo(gameObject.transform.position.y) >= 0)
        {
            SobrePlataforma = true;
        }

        if (PosY.position.y.CompareTo(gameObject.transform.position.y) < 0)
        {
            SobrePlataforma = false;
        }

        if (SobrePlataforma)
        {
            gameObject.GetComponent<BoxCollider2D>().size = tamaño;
        }

        if (!SobrePlataforma)
        {
            gameObject.GetComponent<BoxCollider2D>().size = gameObject.GetComponent<BoxCollider2D>().size - gameObject.GetComponent<BoxCollider2D>().size;
        }

        if (Input.GetKey("s")) 
        {
            gameObject.GetComponent<BoxCollider2D>().size = gameObject.GetComponent<BoxCollider2D>().size - gameObject.GetComponent<BoxCollider2D>().size;
        }


    }
}
