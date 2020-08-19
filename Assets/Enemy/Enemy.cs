using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Variables para gestionar el radio de vision y velocidad
    public float visionRadius;
    public float speed;
    public int option;
    public GameObject player;

    private Boolean devolviendose;

    //Variable para guardar la posicion
    //GameObject player;
    //Variable para guardar la posicion inicial
    Vector3 initialPosition;
    Vector3 target;


    // Start is called before the first frame update
    void Start()
    {   
        //Recuperamos al jugador gracias al tag
        //player = GameObject.FindGameObjectWithTag("Player");

        //Guardamos nuestra posicion inicial
        initialPosition = transform.position;
        target = gameObject.transform.position;
    }
        
    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<Animator>().GetBool("Muerto"))
            {
            if (option == 1)
            {
                //Por defecto nuestro objetivo siempre sera nuestra posicion inicial 
                target = initialPosition;
                //Pero si la distancia hasta el jugador es menor que el radio de vision el objetivo sera él
                float dist = Vector3.Distance(player.transform.position, transform.position);
                if (dist < visionRadius)
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
                    devolviendose = false;
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
                    gameObject.GetComponent<Animator>().SetBool("vePlayer", false);
                    devolviendose = true;
                    if (gameObject.transform.position.x - target.x > 0)
                    {
                        gameObject.GetComponent<SpriteRenderer>().flipX = true;
                        gameObject.GetComponent<Animator>().SetBool("vePlayer", true);
                    }
                    else if (gameObject.transform.position.x - target.x == 0)
                    {
                        gameObject.GetComponent<Animator>().SetBool("vePlayer", false);
                    }
                    else
                    {
                        gameObject.GetComponent<SpriteRenderer>().flipX = false;
                        gameObject.GetComponent<Animator>().SetBool("vePlayer", true);
                    }

                }


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
            if (dist < visionRadius) target = new Vector3(player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

            //Finalmente movemos el enemigo en direccion a su target
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        }

        else if (option == 3)
        {
            //nada, esta patrullando.
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
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, visionRadius);
        }

    
}
