using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss4Controller : MonoBehaviour
{
    public GameObject player;
    public float visionRadius1;
    public float visionRadius2;

    public int vida;
    private AudioSource sonido;
    public AudioClip sonidoCaminar;

    public AudioClip audioMuerteEnemigo;
    public float initialSpeed;
    private float speed2;
    private int contador;
    public GameObject textoContadorEnemigos;
    private float contAux;
    private Vector3 target;
    
    public GameObject bulletPrefab;
    public GameObject guiaMano;
    private Vector3 posMano;

    public GameObject recolectable;
    private float contadorRecolectable;
    




    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().SetBool("VePlayer", false);
        PlayerPrefs.SetInt("vidajefe", vida);
        sonido = GetComponent<AudioSource>();
        if (recolectable != null)
        {
            recolectable.SetActive(false);

        }


    }

    // Update is called once per frame
    void Update()
    {

        float dist = Vector3.Distance(player.transform.position, transform.position);
        posMano = guiaMano.transform.position;

        if (PlayerPrefs.GetInt("vidajefe") <= 0) //Se muere
        {
            contadorRecolectable = contadorRecolectable + Time.deltaTime;
            gameObject.GetComponent<Animator>().SetBool("Muerto", true);
            gameObject.GetComponent<Animator>().SetBool("VePlayer", false);
            gameObject.GetComponent<Animator>().SetBool("Atacar", false);
            speed2 = 0;
            contador = Int32.Parse(textoContadorEnemigos.GetComponent<Text>().text);
            contador = 0;
            textoContadorEnemigos.GetComponent<Text>().text = contador.ToString();
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

        //---------------------------------AUDIO-----------------------------------------------------
        if (gameObject.GetComponent<Animator>().GetBool("VePlayer") && sonido.clip != sonidoCaminar) //Caminando
        {
         
            sonido.Stop();
            sonido.clip = sonidoCaminar;
            sonido.loop = true;
            sonido.Play();
        }
        
    
        

        if (gameObject.GetComponent<Animator>().GetBool("Muerto") && sonido.clip != audioMuerteEnemigo) //Se muere el boss
        {
          
            sonido.Stop();
            sonido.clip = audioMuerteEnemigo;
            sonido.loop = false;
            sonido.Play();
        }
        //--------------------FIN AUDIO----------------------------------------------

        if (!gameObject.GetComponent<Animator>().GetBool("Muerto") && PlayerPrefs.GetInt("Vida") > 0) //Si no está muerto
        {
            if (dist <= visionRadius1) //Lo ve
            {

                //------------------Flipeos-----------------------------
                if (gameObject.transform.position.x - target.x > 0)
                {
                    gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f); //flip false         
                }
                if (gameObject.transform.position.x - target.x < 0)
                {
                    gameObject.transform.localScale = new Vector3(-0.6f, 0.6f, 0.6f); //flip true
                }
                //------------------Fin Flipeos-----------------------------

                gameObject.GetComponent<Animator>().SetBool("VePlayer", true);

                if (gameObject.transform.position.x == player.transform.position.x &&
                    gameObject.transform.position.x == player.transform.position.x) //El player está arriba del boss
                {
                    gameObject.GetComponent<Animator>().SetBool("VePlayer", false);
                    gameObject.GetComponent<Animator>().SetBool("Atacar", false);
                }

                if (dist > visionRadius2) //No está tan cerca para atacar, pero lo ve
                {
                    target = new Vector3(player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                    gameObject.GetComponent<Animator>().SetBool("Atacar", false);
                    gameObject.GetComponent<Animator>().SetBool("VePlayer", true);
                    speed2 = initialSpeed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, target, speed2); //Te sigue
   
                }
                //---------------Ataque----------------------------------
                if (dist <= visionRadius2) //Está en la distancia para atacar
                {
                    target = new Vector3(player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                    gameObject.GetComponent<Animator>().SetBool("Atacar", true);
                    
                    contAux = contAux + Time.deltaTime;
                    speed2 = 0;
                    transform.position = Vector3.MoveTowards(transform.position, target, speed2);
                
                }
                //---------------Fin Ataque-------------------------



            }
            else //Si no lo ve
            {

                gameObject.GetComponent<Animator>().SetBool("VePlayer", false);
                gameObject.GetComponent<Animator>().SetBool("Atacar", false);
                speed2 = 0;
                transform.position = Vector3.MoveTowards(transform.position, target, speed2);


                //-----------------Flipeos---------------------
                if (gameObject.transform.position.x - target.x > 0)
                {
                    gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f); //flip false         
                }
                if (gameObject.transform.position.x - target.x < 0)
                {
                    gameObject.transform.localScale = new Vector3(-0.6f, 0.6f, 0.6f); //flip true
                }
                //-----------------Fin Flipeos---------------------
            }
        }

        if ((PlayerPrefs.GetInt("Vida") <= 0) && (!gameObject.GetComponent<Animator>().GetBool("Muerto"))) //Si el player muere
        {
            gameObject.GetComponent<Animator>().SetBool("VePlayer", false);
            gameObject.GetComponent<Animator>().SetBool("Atacar", false);
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            PlayerPrefs.SetInt("vidajefe", PlayerPrefs.GetInt("vidajefe")-1);
        }
    }

    public void lanzamiento()
    {
        Instantiate(bulletPrefab, posMano, Quaternion.identity);
    }
}
