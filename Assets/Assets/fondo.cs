using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fondo : MonoBehaviour
{
    public GameObject camara;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position.y() = camara.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
