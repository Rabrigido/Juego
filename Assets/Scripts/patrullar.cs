using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrullar : MonoBehaviour
{
    public Transform target;

    public float speed;
    public float speed2;
    public Boolean derecha;
    private Vector3 start;
    private Vector3 end;
    private float resta;
    

    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
        {
            derecha = true;
            start = transform.position;
            end = target.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        resta = gameObject.transform.position.x - end.x;
        //Debug.Log(resta);
        if (resta < 0) derecha = true;
        if (resta > 0) derecha = false;
        if (target != null)
        {
            if (transform.position == end)
            {

                Vector3 aux = start;
                start = end;
                end = aux;
            }

        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {

            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, end, fixedSpeed);
        }
    }
}
