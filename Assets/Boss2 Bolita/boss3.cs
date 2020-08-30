using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class boss3 : MonoBehaviour
{
    private Transform target;
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public Transform target5;
    public Transform target6;
    public Transform target7;
    public Transform target8;
    public int vida;
    private int contador;
    private float speed;
    public float speed1;
    public float speed2;
    public float speed3;
    public float speed4;
    public Boolean derecha;
    private Vector3 start;
    private Vector3 end;
    private float resta;
    private float contadorInicio;
    private float contadorMedio;
    private Boolean move;
    private static readonly Random getrandom = new Random();
    public GameObject recolectable;
    private float contadorRecolectable = 0;
    public GameObject textoContadorEnemigos;
    public GameObject audioMuerteEnemigo;
    public AudioClip audioMover;
    private AudioSource fuenteAudio;
    private Boolean caminando = false;
    private Boolean cmurio = true;


    // Start is called before the first frame update
    void Start()
    {
        fuenteAudio = gameObject.GetComponent<AudioSource>();
        if (recolectable != null)
        {
            recolectable.SetActive(false);

        }
        PlayerPrefs.SetInt("vidajefe", vida);
        System.Random ran = new System.Random();
        target = target4;
        if (target != null)
        {
            derecha = false;
            end = target.position;
        }
        speed = speed1;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("vidajefe") <= 0)
        {
            contador = Int32.Parse(textoContadorEnemigos.GetComponent<Text>().text);
            contador--;
            textoContadorEnemigos.GetComponent<Text>().text = contador.ToString();
            contadorRecolectable = contadorRecolectable + Time.deltaTime;
            move = false;
            gameObject.GetComponent<Animator>().SetBool("move", false);
            gameObject.GetComponent<Animator>().SetBool("muerto", true);
            if (cmurio)
            {
                Destroy(Instantiate(audioMuerteEnemigo, gameObject.transform.position, Quaternion.identity), 3);
                cmurio = false;
            }
            if (recolectable != null)
            {

                if (contadorRecolectable > 1)
                {
                    if (!recolectable.activeSelf)
                    {
                        recolectable.transform.position = gameObject.transform.position;
                        recolectable.SetActive(true);
                    }

                }

            }
        }
        if (!gameObject.GetComponent<Animator>().GetBool("muerto"))
        {
            if (gameObject.GetComponent<Animator>().GetBool("move") && !caminando)
            {
                fuenteAudio.clip = audioMover;
                fuenteAudio.loop = true;
                fuenteAudio.Play();
                caminando = true;
            }
            if (!gameObject.GetComponent<Animator>().GetBool("move"))
            {
                fuenteAudio.Stop();
                caminando = false;
            }
            contadorInicio = contadorInicio + Time.deltaTime;
            if (contadorInicio >= 10 && contadorInicio < 11)
            {
                move = true;
                gameObject.GetComponent<Animator>().SetBool("move", true);
            }
            if (contadorInicio >= 10)
            {
                contadorMedio = contadorMedio + Time.deltaTime;

                if (porcentaje() >= 75)
                {
                    if (contadorMedio >= 4 && contadorMedio < 5)
                    {
                        speed = speed1;
                        move = true;
                        gameObject.GetComponent<Animator>().SetBool("move", true);
                    }
                }
                if (porcentaje() >= 50 && porcentaje() < 75)
                {
                    if (contadorMedio >= 3 && contadorMedio < 4)
                    {
                        speed = speed2;
                        move = true;
                        gameObject.GetComponent<Animator>().SetBool("move", true);
                    }
                }
                if (porcentaje() >= 25 && porcentaje() < 50)
                {
                    if (contadorMedio >= 2 && contadorMedio < 3)
                    {
                        speed = speed3;
                        move = true;
                        gameObject.GetComponent<Animator>().SetBool("move", true);
                    }
                }
                if (porcentaje() >= 0 && porcentaje() < 25)
                {
                    if (contadorMedio >= 1 && contadorMedio < 2)
                    {
                        speed = speed4;
                        move = true;
                        gameObject.GetComponent<Animator>().SetBool("move", true);
                    }
                }
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
                    int numero = GetRandomNumber(1, 9);
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
                    if (numero == 6)
                    {
                        contadorMedio = 0;
                        Vector3 aux = target6.position;
                        numero = 0;
                        end = aux;
                    }
                    if (numero == 7)
                    {
                        contadorMedio = 0;
                        Vector3 aux = target7.position;
                        numero = 0;
                        end = aux;
                    }
                    if (numero == 8)
                    {
                        contadorMedio = 0;
                        Vector3 aux = target8.position;
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
            PlayerPrefs.SetInt("vidajefe", (PlayerPrefs.GetInt("vidajefe") - 1));
        }
    }
    private float porcentaje()
    {
        return ((PlayerPrefs.GetInt("vidajefe") * 100) / vida);
    }
}
