using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class boss3 : MonoBehaviour
{
    private Transform target;
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public Transform target5;
    public float speed;
    public float speed2;
    public Boolean derecha;
    private Vector3 start;
    private Vector3 end;
    private float resta;
    private float contadorInicio;
    private float contadorMedio;
    private Boolean move;
    private static readonly Random getrandom = new Random();

    private int vida;

    // Start is called before the first frame update
    void Start()
    {
        vida = 6;
        System.Random ran = new System.Random();
        target = target1;
        if (target != null)
        {
            derecha = false;
            end = target.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (vida == 0)
        {
            gameObject.GetComponent<Animator>().SetBool("move", false);
            gameObject.GetComponent<Animator>().SetBool("muerto", true);
        }
        if (!gameObject.GetComponent<Animator>().GetBool("muerto"))
        {
            contadorInicio = contadorInicio + Time.deltaTime;
            contadorMedio = contadorMedio + Time.deltaTime;
            if (contadorInicio >= 2 && contadorInicio < 3)
            {
                move = true;
                gameObject.GetComponent<Animator>().SetBool("move", true);
            }

            if (contadorMedio >= 1 && contadorMedio < 2)
            {
                move = true;
                gameObject.GetComponent<Animator>().SetBool("move", true);
            }


            resta = gameObject.transform.position.x - end.x;
            if (resta < 0) derecha = true;
            if (resta > 0) derecha = false;
            if (derecha) gameObject.GetComponent<SpriteRenderer>().flipX = false;
            if (!derecha) gameObject.GetComponent<SpriteRenderer>().flipX = true;
            if (target != null)
            {
                if (transform.position == end)
                {
                    move = false;
                    gameObject.GetComponent<Animator>().SetBool("move", false);
                    int numero = GetRandomNumber(1, 6);
                    if (numero == 1)
                    {
                        contadorMedio = 0;
                        Vector3 aux = target1.position;
                        numero = 0;
                        end = aux;
                    }
                    if (numero == 2)
                    {
                        contadorMedio = 0;
                        Vector3 aux = target2.position;
                        numero = 0;
                        end = aux;
                    }
                    if (numero == 3)
                    {
                        contadorMedio = 0;
                        Vector3 aux = target3.position;
                        numero = 0;
                        end = aux;
                    }
                    if (numero == 4)
                    {
                        contadorMedio = 0;
                        Vector3 aux = target4.position;
                        numero = 0;
                        end = aux;
                    }
                    if (numero == 5)
                    {
                        contadorMedio = 0;
                        Vector3 aux = target5.position;
                        numero = 0;
                        end = aux;
                    }
                }

            }
        }
    }
    void FixedUpdate()
    {
        if (target != null)
        {
            if (move)
            {
                float fixedSpeed = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, end, fixedSpeed);
            }
        }
    }
    private static int GetRandomNumber(int min, int max)
    {
        lock (getrandom)
        {
            return getrandom.Next(min, max);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.gameObject.tag == "Bala")
        {
            vida--;
        }
    }
}
