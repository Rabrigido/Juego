﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    
    public float bulletSpeed;
    public float bulletLife;
    public string tagg;
    private GameObject gun;
    private GameObject player;
    public AudioClip audioDisparo;
    private AudioSource fuenteAudio;
    private Rigidbody2D bulletRB;
    private float originalScaleX;

    //public GameObject choqueBala;
    // Start is called before the first frame update

    void Awake()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        gun = GameObject.FindGameObjectWithTag(tagg);
        player = GameObject.FindGameObjectWithTag(tagg);
        originalScaleX = transform.localScale.x;

    }

    void Start()
    {
        
        if (player.GetComponent<SpriteRenderer>().flipX)
        {
            transform.localScale = new Vector3(-originalScaleX, transform.localScale.y, transform.localScale.z);
            bulletRB.velocity = new Vector2(-bulletSpeed, bulletRB.velocity.y);
        }
        else if(!player.GetComponent<SpriteRenderer>().flipX)
        {
            transform.localScale = new Vector3(originalScaleX, transform.localScale.y, transform.localScale.z);
            bulletRB.velocity = new Vector2(bulletSpeed, bulletRB.velocity.y);

        }

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, bulletLife);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //Instantiate(choqueBala);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {

            //Instantiate(choqueBala);

            Destroy(gameObject);

        }

    }

}
