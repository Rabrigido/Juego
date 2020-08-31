using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MuerteXSeg : MonoBehaviour
{
    public float segundosFloat;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, segundosFloat);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
