using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
    public float visionRadius1;
    public float visionRadius2;
    public GameObject player;
    public int initialSpeed;
    private float speed2;
    Vector3 target;
    public float minX;
    public float maxX;
    public float maxY;
    public GameObject puntoInicial;
    public int vida;
    public GameObject textoContadorEnemigos;
    private int contador;
    public GameObject recolectable;
    float contadorRecolectable = 0;
    public GameObject audioMuerteEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().SetBool("Acercarse", false);
        PlayerPrefs.SetInt("vidajefe",vida);
        if (recolectable != null)
        {
            recolectable.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("vidajefe") <= 0) //Se muere
        {
            gameObject.GetComponent<Animator>().SetBool("Muerto", true);
            gameObject.GetComponent<Animator>().SetBool("Acercarse", false);
            gameObject.GetComponent<Animator>().SetBool("Atacar", false);
            speed2 = 0;
            contador = Int32.Parse(textoContadorEnemigos.GetComponent<Text>().text);
            contador--;
            textoContadorEnemigos.GetComponent<Text>().text = contador.ToString();

            contadorRecolectable = contadorRecolectable + Time.deltaTime;

            if (recolectable != null)
            {

                if (contadorRecolectable > 1.4)
                {
                    if (!recolectable.activeSelf)
                    {
                        recolectable.transform.position = gameObject.transform.position;
                        recolectable.SetActive(true);
                    }

                }

            }
        }

        Debug.Log("VIDA BOSS: " + PlayerPrefs.GetInt("vidajefe"));


        float dist = Vector3.Distance(player.transform.position, transform.position);
        

        if (!gameObject.GetComponent<Animator>().GetBool("Muerto") && PlayerPrefs.GetInt("Vida") > 0) //Si no está muerto
        {
            if ((player.transform.position.x >= minX && player.transform.position.x <= maxX) && (player.transform.position.y < maxY)) //Lo ve
            {
                if (gameObject.transform.position.x - player.transform.position.x > 0) //flipeo
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                if (gameObject.transform.position.x - player.transform.position.x < 0) //flipeo
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }

                gameObject.GetComponent<Animator>().SetBool("Acercarse", true);

                if (gameObject.transform.position.x == player.transform.position.x && 
                    gameObject.transform.position.x == player.transform.position.x) //El player está arriba del boss
                {
                    gameObject.GetComponent<Animator>().SetBool("Acercarse", false);
                    gameObject.GetComponent<Animator>().SetBool("Atacar", false);
                }

                if (dist <= visionRadius2) //Está en la distancia para atacar
                {
                    speed2 = 0;
                    gameObject.GetComponent<Animator>().SetBool("Atacar", true);
                    gameObject.GetComponent<Animator>().SetBool("Acercarse", false);
                    transform.position = Vector3.MoveTowards(transform.position, target, speed2);
                }
                if (dist > visionRadius2)  //No está tan cerca para atacar
                {
                    target = new Vector3(player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                    gameObject.GetComponent<Animator>().SetBool("Atacar", false);
                    gameObject.GetComponent<Animator>().SetBool("Acercarse", true);

                    if (gameObject.transform.position.x > minX && gameObject.transform.position.x < maxX) //Si está dentro de su espacio
                    {
       
                        speed2 = initialSpeed * Time.deltaTime;
                        transform.position = Vector3.MoveTowards(transform.position, target, speed2); //Te sigue
                        
                    }

                    if (gameObject.transform.position.x == minX || gameObject.transform.position.x == maxX) //Llega al borde
                    {
                        gameObject.GetComponent<Animator>().SetBool("Acercarse", false);
                        speed2 = 0;
                        transform.position = Vector3.MoveTowards(transform.position, target, speed2);
                    }
                }  
            }
            else
            {

                gameObject.GetComponent<Animator>().SetBool("Acercarse", false);
                gameObject.GetComponent<Animator>().SetBool("Atacar", false);
                speed2 = 0;
                if (gameObject.transform.position.x - player.transform.position.x > 0) //flipeo
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                if (gameObject.transform.position.x - player.transform.position.x < 0) //flipeo
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
            }
            /*
            else //No lo ve, por lo tanto se devuelve.
            {

                if (gameObject.transform.position.x - puntoInicial.transform.position.x > 0) //flipeo
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                if (gameObject.transform.position.x - puntoInicial.transform.position.x < 0) //flipeo
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }

                if (gameObject.transform.position.x == puntoInicial.transform.position.x) //Está en el origen
                {
                    gameObject.GetComponent<Animator>().SetBool("Acercarse", false);
                    speed2 = 0;
                    transform.position = Vector3.MoveTowards(transform.position, target, speed2);
                }
                else //Si no está en el origen
                {
                    target = new Vector3(puntoInicial.transform.position.x, transform.position.y, transform.position.z);
                    Debug.Log("Aaa");
                    speed2 = initialSpeed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, target, speed2);
                    gameObject.GetComponent<Animator>().SetBool("Acercarse", true);
                }
            }
            */
            
        }

        if ((PlayerPrefs.GetInt("Vida") <= 0) && (!gameObject.GetComponent<Animator>().GetBool("Muerto")))
        {
            gameObject.GetComponent<Animator>().SetBool("Acercarse", false);
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
            PlayerPrefs.SetInt("vidajefe", (PlayerPrefs.GetInt("vidajefe") - 1));
        }
    }
}
