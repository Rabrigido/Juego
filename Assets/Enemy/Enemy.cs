﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Variables para gestionar el radio de vision y velocidad
    public float visionRadius1;
    public float visionRadius2;
    public float speed;
    public float speed2;
    public int option;
    public GameObject player;

    

    
    //Variable para guardar la posicion inicial
    Vector3 initialPosition;
    Vector3 target;

    public AudioClip audioAtaque;
    public AudioClip audioCaminar;
    private AudioSource fuenteAudio;

    private Boolean caminando = false;



    // Start is called before the first frame update
    void Start()
    {   
        //Recuperamos al jugador gracias al tag
        //player = GameObject.FindGameObjectWithTag("Player");

        //Guardamos nuestra posicion inicial
        initialPosition = transform.position;
        target = gameObject.transform.position;

        fuenteAudio = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Animator>().GetBool("vePlayer") && !caminando){


            fuenteAudio.clip = audioCaminar;
            fuenteAudio.loop = true;
            caminando = true;
            fuenteAudio.Play();

        }
        if (!gameObject.GetComponent<Animator>().GetBool("vePlayer"))
        {
            caminando = false;
        }

        /*
        if (gameObject.GetComponent<Animator>().GetBool("Atacando") && !atacando)
        {

            fuenteAudio.clip = audioAtaque;
            fuenteAudio.loop = true;
            atacando = true;
            fuenteAudio.Play();

        }
        if (!gameObject.GetComponent<Animator>().GetBool("Atacando"))
        {
            atacando = false;
        }
        */

        if (option == 1)
        {
            if (!gameObject.GetComponent<Animator>().GetBool("Muerto"))
            {
                //Por defecto nuestro objetivo siempre sera nuestra posicion inicial 
                target = gameObject.transform.position;
                //Pero si la distancia hasta el jugador es menor que el radio de vision el objetivo sera él
                float dist = Vector3.Distance(player.transform.position, transform.position);
                if (dist < visionRadius1)
                {
                    if (dist <= visionRadius2 && PlayerPrefs.GetInt("Vida") > 0)
                    {

                        gameObject.GetComponent<Animator>().SetBool("Atacando", true);



                        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorClipInfoCount(0) == 20)
                        {
                            int vidaPlayer = PlayerPrefs.GetInt("Vida");
                            vidaPlayer--;
                            PlayerPrefs.SetInt("Vida", vidaPlayer);
                           
                            
                        }
                        
                        gameObject.GetComponent<Animator>().SetBool("vePlayer", false);
                        speed = 0;
                        if (gameObject.transform.position.x - player.transform.position.x > 0)
                        {
                            gameObject.GetComponent<SpriteRenderer>().flipX = true;
                        }
                        if (gameObject.transform.position.x - player.transform.position.x < 0)
                        {
                            gameObject.GetComponent<SpriteRenderer>().flipX = false;
                        }

                    }
                    else
                    {
                        gameObject.GetComponent<Animator>().SetBool("Atacando", false);
                        speed = speed2;
                    }
                    if (!gameObject.GetComponent<Animator>().GetBool("Atacando"))
                    {
                        target = new Vector3(player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                        if (gameObject.transform.position.x - target.x == 0)
                        {
                            gameObject.GetComponent<Animator>().SetBool("vePlayer", false);
                        }
                        else
                        {
                            gameObject.GetComponent<Animator>().SetBool("vePlayer", true);
                        }

                        if (gameObject.transform.position.x - player.transform.position.x > 0)
                        {
                            gameObject.GetComponent<SpriteRenderer>().flipX = true;
                        }
                        if (gameObject.transform.position.x - player.transform.position.x < 0)
                        {
                            gameObject.GetComponent<SpriteRenderer>().flipX = false;
                        }
                    }
                }
                else
                {
                    gameObject.GetComponent<Animator>().SetBool("vePlayer", false);
                }
                //if (dist > visionRadius1)
                //{
                  //  gameObject.GetComponent<Animator>().SetBool("vePlayer", false);
                    //devolviendose = true;
                    //if (gameObject.transform.position.x - target.x > 0)
                 //   {
                 //       gameObject.GetComponent<SpriteRenderer>().flipX = true;
                  //      gameObject.GetComponent<Animator>().SetBool("vePlayer", true);
                  //  }
                  //  else if (gameObject.transform.position.x - target.x == 0)
                  //  {
                 //       gameObject.GetComponent<Animator>().SetBool("vePlayer", false);
                 //   }
                  //  else
                 //   {
                 //       gameObject.GetComponent<SpriteRenderer>().flipX = false;
                 //       gameObject.GetComponent<Animator>().SetBool("vePlayer", true);
                 //   }

               // }


                //Finalmente movemos el enemigo en direccion a su target
                float fixedSpeed = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
            }
        }
        else if (option == 2)
        {
            target = transform.position;
            //Pero si la distancia hasta el jugador es menor que el radio de vision el objetivo sera él
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist < visionRadius1) target = new Vector3(player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

            //Finalmente movemos el enemigo en direccion a su target
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        }

        else if (option == 3)
        {



            if (!gameObject.GetComponent<Animator>().GetBool("Muerto"))
            {
                float dist = Vector3.Distance(player.transform.position, transform.position);
               
                if (dist <= visionRadius2 && PlayerPrefs.GetInt("Vida") > 0)
                {
                    if (gameObject.transform.position.x - player.transform.position.x > 0)
                    {
                        gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    }
                    if (gameObject.transform.position.x - player.transform.position.x < 0)
                    {
                        gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    }
                    gameObject.GetComponent<patrullar>().speed = 0;
                    gameObject.GetComponent<Animator>().SetBool("vePlayer", false);
                    gameObject.GetComponent<Animator>().SetBool("Atacando", true);



                    
                }
                else
                {
                    gameObject.GetComponent<Animator>().SetBool("Atacando", false);
                    gameObject.GetComponent<patrullar>().speed = gameObject.GetComponent<patrullar>().speed2;
                    if (gameObject.GetComponent<patrullar>().derecha)
                    {
                        gameObject.GetComponent<SpriteRenderer>().flipX = false;
                        gameObject.GetComponent<Animator>().SetBool("vePlayer", true);

                    }
                    if (!gameObject.GetComponent<patrullar>().derecha)
                    {
                        gameObject.GetComponent<SpriteRenderer>().flipX = true;
                        gameObject.GetComponent<Animator>().SetBool("vePlayer", true);
                    }
                }
            }
            else
            {
                gameObject.GetComponent<patrullar>().speed = 0;
            }
        }

        else if (option == 4)  //BOSS
        {
            //nada, es un boss.
        }




    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Ground")
        {
            Rigidbody2D m_Rigidbody = gameObject.GetComponent<Rigidbody2D>();

            m_Rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
            
            //RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionZ;
        }      
    }

    void OnDrawGizmos()
        {
            Gizmos.color = UnityEngine.Color.yellow;
            Gizmos.DrawWireSphere(transform.position, visionRadius1);
            Gizmos.color = UnityEngine.Color.red;
            Gizmos.DrawWireSphere(transform.position, visionRadius2);
    }
    public void enemyAttack()
    {

        float distA = Vector3.Distance(player.transform.position, transform.position);
        
        if (distA < visionRadius2 && PlayerPrefs.GetInt("Vida") > 0)
        {

            gameObject.GetComponent<Animator>().SetBool("Atacando", true);
            gameObject.GetComponent<Animator>().SetBool("vePlayer", false);
            speed = 0;
            

            
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Atacando", false);
            gameObject.GetComponent<Animator>().SetBool("vePlayer", true);
            speed = speed2;
        }
    }
    IEnumerator esperarAtaque()
    {
        yield return new WaitForSeconds(3);
        int vidaPlayer = PlayerPrefs.GetInt("Vida");
        vidaPlayer--;
        PlayerPrefs.SetInt("Vida", vidaPlayer);

    }

    public void sonidoAtaque()
    {
        fuenteAudio.clip = audioAtaque;
        fuenteAudio.loop = false;
        fuenteAudio.Play();
    }
}
