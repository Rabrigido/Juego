using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public Transform target;
    
    public float speed;

    private Vector3 start;
    private Vector3 end;

    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
        {
            start = transform.position;
            end = target.position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if( target != null) {
            if(transform.position == end)
            {
                Vector3 aux = start;
                start = end;
                end = aux;
            }

        }
    }

    void FixedUpdate()
    {
        if(target != null)
        {

            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, end, fixedSpeed);
        }
    }
}
