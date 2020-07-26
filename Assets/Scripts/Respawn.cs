using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float threshold;
    Vector3 posicionInicial;
    void Start()
    {
        posicionInicial = GameObject.FindGameObjectWithTag("Player").transform.position;

    }
    void FixedUpdate()
    {
        if (transform.position.y < threshold)
            transform.position = posicionInicial;
    }
}
