using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
public class Boss5 : MonoBehaviour
{
    public GameObject player;
    public GameObject recolectable;
    public GameObject textoContadorEnemigos;
    public float visionRadius1;
    public float visionRadius2;
    public float visionRadius3;
    public int vida;
    public GameObject lugar1;
    public GameObject lugar2;
    public GameObject lugar3;
    private Vector3 target1;
    private Vector3 target2;
    private Vector3 target3;
    private static readonly Random getrandom = new Random();
    private AudioSource sonido;
    public AudioClip sonidoCaminar;
    public AudioClip audioMuerteEnemigo;
    public AudioClip sonidoGarra;
    public float initialSpeed;
    private float speed2;
    private int contador;
    private float contAux;
    private Vector3 target;
    public GameObject guiaMano;
    public GameObject bulletPrefab;
    public float porc;
    private Vector3 posMano;
    public int numero;
    public int contTP;
    private float contadorRecolectable = 0;
    public Boolean tepeado;
    // Start is called before the first frame update
    void Start()
    {
        if (recolectable != null)
        {
            recolectable.SetActive(false);

        }
        gameObject.GetComponent<Animator>().SetBool("move", false);
        gameObject.GetComponent<Animator>().SetBool("TP", false);
        gameObject.GetComponent<Animator>().SetBool("aCola", false);
        gameObject.GetComponent<Animator>().SetBool("aGarra", false);
        PlayerPrefs.SetInt("vidajefe", vida);

        target1 = new Vector3(lugar1.transform.position.x,transform.position.y,transform.position.z);
        target2 = new Vector3(lugar2.transform.position.x, transform.position.y, transform.position.z);
        target3 = new Vector3(lugar3.transform.position.x, transform.position.y, transform.position.z);


        contTP = 0;
        System.Random ran = new System.Random();
        sonido = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //----------------Intentando tepear-------------------------------
        porc = porcentaje();
        if (tepeado)
        {
            gameObject.GetComponent<Animator>().SetBool("TP", false);
            tepeado = false;
        }
        
        if (porcentaje() < 90 && contTP == 0)
        {
            numero = GetRandomNumber(1, 4);
            gameObject.GetComponent<Animator>().SetBool("TP", true);
            contTP = 1; 
        }
        if (porcentaje() < 70 && contTP == 1)
        {
            numero = GetRandomNumber(1, 4);
            gameObject.GetComponent<Animator>().SetBool("TP", true);
            contTP = 2;
        }
        if (porcentaje() < 50 && contTP == 2)
        {
            numero = GetRandomNumber(1, 4);
            gameObject.GetComponent<Animator>().SetBool("TP", true);
            contTP = 3;
        }
        if (porcentaje() < 30 && contTP == 3)
        {
            numero = GetRandomNumber(1, 4);
            gameObject.GetComponent<Animator>().SetBool("TP", true);
            contTP = 4;
        }
        if (porcentaje() < 10 && contTP == 4)
        {
            numero = GetRandomNumber(1, 4);
            gameObject.GetComponent<Animator>().SetBool("TP", true);
            contTP = 5;
        }

        float dist = Vector3.Distance(player.transform.position, transform.position);
        posMano = guiaMano.transform.position;
       
        if (PlayerPrefs.GetInt("vidajefe") <= 0) //Se muere
        {
            gameObject.GetComponent<Animator>().SetBool("Muerto", true);
            gameObject.GetComponent<Animator>().SetBool("move", false);
            gameObject.GetComponent<Animator>().SetBool("aCola", false);
            gameObject.GetComponent<Animator>().SetBool("aGarra", false);
            textoContadorEnemigos.GetComponent<Text>().text = contador.ToString();
            contadorRecolectable = contadorRecolectable + Time.deltaTime;

            speed2 = 0;
            
            contador = Int32.Parse(textoContadorEnemigos.GetComponent<Text>().text);
            contador--;
            textoContadorEnemigos.GetComponent<Text>().text = contador.ToString();
            
            if (recolectable != null)
            {

                if (contadorRecolectable >0)
                {
                    if (!recolectable.activeSelf)
                    {
                        recolectable.transform.position = gameObject.transform.position;
                        recolectable.SetActive(true);
                    }

                }

            }
        }

        //---------------------------------AUDIO-----------------------------------------------------
        /*if (gameObject.GetComponent<Animator>().GetBool("move") && sonido.clip != sonidoCaminar) //Caminando
        {

            sonido.Stop();
            sonido.clip = sonidoCaminar;
            sonido.loop = true;
            sonido.Play();
        }*/




        if (gameObject.GetComponent<Animator>().GetBool("Muerto") && sonido.clip != audioMuerteEnemigo) //Se muere el boss
        {

            sonido.Stop();
            sonido.clip = audioMuerteEnemigo;
            sonido.loop = false;
            sonido.Play();
        }

        /*if(gameObject.GetComponent<Animator>().GetBool("aGarra") && sonido.clip != sonidoGarra)
        {
            sonido.Stop();
            sonido.clip = sonidoGarra;
            sonido.loop = true;
            sonido.Play();
        }*/
        //--------------------FIN AUDIO----------------------------------------------

        if (!gameObject.GetComponent<Animator>().GetBool("Muerto") && PlayerPrefs.GetInt("Vida") > 0) //Si no está muerto
        {
            if (dist <= visionRadius1) //Lo ve
            {

                //------------------Flipeos-----------------------------
                if (gameObject.transform.position.x - player.transform.position.x > 0)
                {
                    gameObject.transform.localScale = new Vector3(-1, 1, 1); //flip true

                }
                if (gameObject.transform.position.x - player.transform.position.x < 0)
                {
                    gameObject.transform.localScale = new Vector3(1, 1, 1); //flip false
                    
                }
                //------------------Fin Flipeos-----------------------------

                gameObject.GetComponent<Animator>().SetBool("move", true);

                if (gameObject.transform.position.x == player.transform.position.x &&
                    gameObject.transform.position.x == player.transform.position.x) //El player está arriba del boss
                {
                    gameObject.GetComponent<Animator>().SetBool("move", false);
                    gameObject.GetComponent<Animator>().SetBool("aCola", false);
                    gameObject.GetComponent<Animator>().SetBool("aGarra", false);
                }

                if (dist > visionRadius2) //No está tan cerca para atacar, pero lo ve
                {
                    target = new Vector3(player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                    gameObject.GetComponent<Animator>().SetBool("aCola", false);
                    gameObject.GetComponent<Animator>().SetBool("aGarra", false);
                    gameObject.GetComponent<Animator>().SetBool("move", true);
                    
                    speed2 = initialSpeed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, target, speed2); //Te sigue


                }
                //---------------Ataque Cola----------------------------------
                if (dist <= visionRadius2 && dist>visionRadius3) //Está en la distancia para atacar
                {
                    gameObject.GetComponent<Animator>().SetBool("aCola", true);
                    gameObject.GetComponent<Animator>().SetBool("aGarra", false);
                    gameObject.GetComponent<Animator>().SetBool("move", false);


                    contAux = contAux + Time.deltaTime;
                    speed2 = 0;
                    transform.position = Vector3.MoveTowards(transform.position, target, speed2);

                    if (contAux > 1.1f)
                    {
                        //lanzamiento();
                        contAux = 0;
                    }

                }
                //-----------------Ataque Garra-------------------
                if(dist<=visionRadius3)
                {
                    gameObject.GetComponent<Animator>().SetBool("aCola", false);
                    gameObject.GetComponent<Animator>().SetBool("move", false);
                    gameObject.GetComponent<Animator>().SetBool("aGarra", true);


                }
                //---------------Fin Ataque-------------------------
            }
            else //Si no lo ve
            {

                gameObject.GetComponent<Animator>().SetBool("move", false);
                gameObject.GetComponent<Animator>().SetBool("aCola", false);
                gameObject.GetComponent<Animator>().SetBool("aGarra", false);
                speed2 = 0;
                transform.position = Vector3.MoveTowards(transform.position, target, speed2);


                //-----------------Flipeos---------------------
                if (gameObject.transform.position.x - player.transform.position.x > 0)
                {
                    gameObject.transform.localScale = new Vector3(1, 1, 1); //flip false

                }
                if (gameObject.transform.position.x - player.transform.position.x < 0)
                {

                    gameObject.transform.localScale = new Vector3(-1, 1, 1); //flip true
                }
                //-----------------Fin Flipeos---------------------
            }
        }

        if ((PlayerPrefs.GetInt("Vida") <= 0) && (!gameObject.GetComponent<Animator>().GetBool("Muerto"))) //Si el player muere
        {
            gameObject.GetComponent<Animator>().SetBool("move", false);
            gameObject.GetComponent<Animator>().SetBool("aCola", false);
            gameObject.GetComponent<Animator>().SetBool("aGarra", false);
            transform.position = Vector3.MoveTowards(transform.position, target, speed2);
            speed2 = 0;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius1);
        Gizmos.color = UnityEngine.Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadius2);
        Gizmos.color = UnityEngine.Color.green;
        Gizmos.DrawWireSphere(transform.position, visionRadius3);
    }

    public void lanzamiento()
    {
        Instantiate(bulletPrefab, posMano, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            PlayerPrefs.SetInt("vidajefe", PlayerPrefs.GetInt("vidajefe") - 1);
        }
    }
    private float porcentaje()
    {
        return ((PlayerPrefs.GetInt("vidajefe") * 100) / vida);
    }
    public void SonidoAtaque()
    {
        sonido.clip = sonidoGarra;
        sonido.loop = false;
        sonido.Play();
    }
    public void SonidoMoverse()
    {
        sonido.clip = sonidoCaminar;
        sonido.loop = false;
        sonido.Play();
    }
    private static int GetRandomNumber(int min, int max)
    {
        lock (getrandom)
        {
            return getrandom.Next(min, max);
        }
    }
    public void FinTepeo()
    {
        tepeado = true;
    }
    public void Tepeo()
    {
        if (numero == 1)
        {
            transform.position = target1;
        }
        if (numero == 2)
        {
            transform.position = target2;
        }
        if (numero == 3)
        {
            transform.position = target3;
        }
        
    }
}
