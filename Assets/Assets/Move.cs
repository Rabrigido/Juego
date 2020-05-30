using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }    

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("left"))
        {
            gameObject.transform.Translate(-2f * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("right"))
        {
            gameObject.transform.Translate(2f * Time.deltaTime, 0, 0);
        }        
    }
}
