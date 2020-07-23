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


    

    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;

    }

    // Update is called once per frame
    void Update()
    {
        

        if (PosY.position.y.CompareTo(gameObject.transform.position.y) >= 0)
        {
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;

        }

        if (PosY.position.y.CompareTo(gameObject.transform.position.y) < 0)
        {
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
            gameObject.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
        }

       
        if (Input.GetKey("s")) 
        {
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
            gameObject.GetComponent<PlatformEffector2D>().rotationalOffset = 180;
        }


    }
}
