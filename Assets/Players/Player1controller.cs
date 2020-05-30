﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1controller : MonoBehaviour
{
    Boolean canjump;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            gameObject.transform.Translate(-10f * Time.deltaTime, 0, 0);
            gameObject.GetComponent<Animator>().SetBool("Move", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey("d"))
        {
            gameObject.transform.Translate(10f * Time.deltaTime, 0, 0);
            gameObject.GetComponent<Animator>().SetBool("Move", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (!Input.GetKey("d") && !Input.GetKey("a"))
        {
            gameObject.GetComponent<Animator>().SetBool("Move", false);
            gameObject.GetComponent<Animator>().SetBool("Move", false);

        }
        if (Input.GetKey("d") && Input.GetKey("c"))
        {
            gameObject.transform.Translate(10f * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a") && Input.GetKey("c"))
        {
            gameObject.transform.Translate(-10f * Time.deltaTime, 0, 0);
        }
    }

    private void OnCollosionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            canjump = true;
        }
    }
}
