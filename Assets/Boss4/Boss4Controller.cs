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
    //public GameObject textoContadorEnemigos;
    private float contAux;
    private Vector3 target;
    public GameObject guiaMano;
    public GameObject bulletPrefab;
    private Vector3 posMano;
   



    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().SetBool("VePlayer", false);
        PlayerPrefs.SetInt("vidajefe", vida);
        sonido = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        posMano = guiaMano.transform.position;

        if (PlayerPrefs.GetInt("vidajefe") <= 0) //Se muere
        {
            gameObject.GetComponent<Animator>().SetBool("Muerto", true);
            gameObject.GetComponent<Animator>().SetBool("VePlayer", false);
            gameObject.GetComponent<Animator>().SetBool("Atacar", false);
            speed2 = 0;
            /*
            contador = Int32.Parse(textoContadorEnemigos.GetComponent<Text>().text);
            contador--;
            textoContadorEnemigos.GetComponent<Text>().text = contador.ToString();
            */
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
                if (gameObject.transform.position.x - player.transform.position.x > 0)
                {
                    gameObject.transform.localScale = new Vector3(1,1,1); //flip false
                    
                }
                if (gameObject.transform.position.x - player.transform.position.x < 0)
                {
                    
                    gameObject.transform.localScale = new Vector3(-1, 1, 1); //flip true
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
                    gameObject.GetComponent<Animator>().SetBool("Atacar", true);
                    
                    contAux = contAux + Time.deltaTime;
                    speed2 = 0;
                    transform.position = Vector3.MoveTowards(transform.position, target, speed2);

                    if (contAux > 1.1f)
                    {
                        //lanzamiento();
                        contAux = 0;
                    }
                    
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

    public void lanzamiento()
    {
        Instantiate(bulletPrefab, posMano, Quaternion.identity);
    }
}
