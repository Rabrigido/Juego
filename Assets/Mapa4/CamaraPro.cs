using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class CamaraPro : MonoBehaviour
{
    public GameObject personaje;
    public Vector2 minCamPos, maxCampPos;
    public float smoothTime;

    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x,personaje.transform.position.x, ref velocity.x, smoothTime);
        float posY = Mathf.SmoothDamp(transform.position.y, personaje.transform.position.y, ref velocity.y, smoothTime);
        
        transform.position = new Vector3(Mathf.Clamp(posX, minCamPos.x, maxCampPos.x), Mathf.Clamp(posY, minCamPos.y, maxCampPos.y),transform.position.z);
       
    }
}
