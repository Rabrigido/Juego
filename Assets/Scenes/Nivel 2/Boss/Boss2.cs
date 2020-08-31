using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Boss2 : MonoBehaviour
{
    public float visionRadius1;
    public float visionRadius2;
    public GameObject player;
    Vector3 target;
    public int vida;
    private float contador;
    private float contador2;
    public float speed;
    private int number;
    private float speed2;
    private static readonly Random getrandom = new Random();
    public GameObject recolectable;
    private float contadorRecolectable = 0;
    public GameObject textoContadorEnemigos;
    public GameObject audioMuerteEnemigo;
    public AudioClip audioMover;
    public AudioClip audioGarra;
    public AudioClip audioCola;
    public AudioClip audioOler;
    private AudioSource fuenteAudio;
    private Boolean cmurio = true;
    private float contAuxG;
    private float contAuxC;
    private float contAtaque;
    private Boolean ataque;

    // Start is called before the first frame update
    void Start()
    {
        target = gameObject.transform.position;
        PlayerPrefs.SetInt("vidajefe", vida);
        if (recolectable != null)
        {
            recolectable.SetActive(false);

        }
        fuenteAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("vidajefe") <= 0)
        {
            fuenteAudio.Stop();
            gameObject.GetComponent<Animator>().SetBool("smell", false);
            gameObject.GetComponent<Animator>().SetBool("ataqueGarra", false);
            gameObject.GetComponent<Animator>().SetBool("ataqueCola", false);
            gameObject.GetComponent<Animator>().SetBool("move", false);
            gameObject.GetComponent<Animator>().SetBool("death", true);
            contador = Int32.Parse(textoContadorEnemigos.GetComponent<Text>().text);
            contador--;
            textoContadorEnemigos.GetComponent<Text>().text = contador.ToString();
            contadorRecolectable = contadorRecolectable + Time.deltaTime;
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
        if (!gameObject.GetComponent<Animator>().GetBool("death"))
        {
            if (gameObject.GetComponent<Animator>().GetBool("move") && fuenteAudio.clip != audioMover) //Caminando
            {
                contAuxG = 0;
                contAuxC = 0;
                fuenteAudio.Stop();
                fuenteAudio.clip = audioMover;
                fuenteAudio.loop = true;
                fuenteAudio.Play();

            }
            if (gameObject.GetComponent<Animator>().GetBool("ataqueGarra") && fuenteAudio.clip != audioGarra && contAuxG >= 1f) //Atacando
            {
                contAuxC = 0;
                fuenteAudio.Stop();
                fuenteAudio.clip = audioGarra;
                fuenteAudio.loop = false;
                fuenteAudio.Play();
            }
            if (gameObject.GetComponent<Animator>().GetBool("ataqueGarra") && fuenteAudio.clip == audioGarra && !fuenteAudio.isPlaying) //Atacando
            {
                contAuxC = 0;
                fuenteAudio.Stop();
                fuenteAudio.clip = audioGarra;
                fuenteAudio.loop = false;
                fuenteAudio.Play();
            }
            if (gameObject.GetComponent<Animator>().GetBool("ataqueCola") && fuenteAudio.clip != audioCola && contAuxC >= 1f) //Atacando
            {
                contAuxG = 0;
                fuenteAudio.Stop();
                fuenteAudio.clip = audioCola;
                fuenteAudio.loop = false;
                fuenteAudio.Play();
            }
            if (gameObject.GetComponent<Animator>().GetBool("ataqueCola") && fuenteAudio.clip == audioCola && !fuenteAudio.isPlaying) //Atacando
            {
                contAuxG = 0;
                fuenteAudio.Stop();
                fuenteAudio.clip = audioCola;
                fuenteAudio.loop = false;
                fuenteAudio.Play();
            }
            if (gameObject.GetComponent<Animator>().GetBool("smell") && fuenteAudio.clip != audioOler) //Atacando
            {
                contAuxG = 0;
                contAuxC = 0;
                fuenteAudio.Stop();
                fuenteAudio.clip = audioOler;
                fuenteAudio.loop = false;
                fuenteAudio.Play();
            }
            if (gameObject.GetComponent<Animator>().GetBool("smell") && fuenteAudio.clip == audioOler && !fuenteAudio.isPlaying) //Atacando
            {
                contAuxG = 0;
                contAuxC = 0;
                fuenteAudio.Stop();
                fuenteAudio.clip = audioOler;
                fuenteAudio.loop = false;
                fuenteAudio.Play();
            }

            float dist = Vector3.Distance(player.transform.position, transform.position);
            target = new Vector3(player.transform.position.x, gameObject.transform.position.y, 0f);
            if (player.transform.position.x < gameObject.transform.position.x)
            {
                gameObject.transform.localScale = new Vector3(-7, 7, 7);
            }
            if (player.transform.position.x > gameObject.transform.position.x)
            {
                gameObject.transform.localScale = new Vector3(7, 7, 7);
            }
            if(dist < visionRadius1)
            {
                if (contador <= 2) gameObject.GetComponent<Animator>().SetBool("smell", true);          
                contador += Time.deltaTime;
                if(contador > 2)
                {
                    if (!ataque)
                    {
                        gameObject.GetComponent<Animator>().SetBool("smell", false);
                        gameObject.GetComponent<Animator>().SetBool("move", true);
                        if (gameObject.transform.position.x == player.transform.position.x)
                        {
                            contador2 += Time.deltaTime;
                            gameObject.GetComponent<Animator>().SetBool("smell", true);
                            gameObject.GetComponent<Animator>().SetBool("move", false);
                            speed2 = 0;
                        }
                    }

                    contAtaque = contAtaque + Time.deltaTime;
                    if (contAtaque >= 1f) { int number = GetRandomNumber(1, 3); }
                    if (dist <= visionRadius2)
                    {
                        ataque = true;
                        contAuxG = contAuxG + Time.deltaTime;
                        contAuxC = contAuxC + Time.deltaTime;                  
                        int number = GetRandomNumber(1, 3);                          
                        if (number == 1)
                        {
                            speed2 = 0;
                            transform.position = Vector3.MoveTowards(transform.position, target, speed2);
                            gameObject.GetComponent<Animator>().SetBool("move", false);
                            gameObject.GetComponent<Animator>().SetBool("ataqueCola", false);
                            gameObject.GetComponent<Animator>().SetBool("ataqueGarra", true);
                            gameObject.GetComponent<Animator>().SetBool("smell", false);
                        }
                        else if (number == 2)
                        {
                            speed2 = 0;
                            transform.position = Vector3.MoveTowards(transform.position, target, speed2);
                            gameObject.GetComponent<Animator>().SetBool("move", false);
                            gameObject.GetComponent<Animator>().SetBool("ataqueGarra", false);
                            gameObject.GetComponent<Animator>().SetBool("ataqueCola", true);
                            gameObject.GetComponent<Animator>().SetBool("smell", false);
                        }
                        contAtaque = 0;                                           
                    }
                    if (dist > visionRadius2)
                    {
                        ataque = false;
                        if (!gameObject.GetComponent<Animator>().GetBool("smell"))
                        {
                            gameObject.GetComponent<Animator>().SetBool("ataqueGarra", false);
                            gameObject.GetComponent<Animator>().SetBool("ataqueCola", false);
                            speed2 = speed * Time.deltaTime;
                            gameObject.GetComponent<Animator>().SetBool("move", true);
                            transform.position = Vector3.MoveTowards(transform.position, target, speed2);
                        }
                    }
                    transform.position = Vector3.MoveTowards(transform.position, target, speed2);
                }
            }
            else
            {
                GetComponent<Animator>().SetBool("move", false);
                GetComponent<Animator>().SetBool("smell", false);
                GetComponent<Animator>().SetBool("ataqueCola", false);
                GetComponent<Animator>().SetBool("ataqueGarra", false);
                contador = 0;
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius1);
        Gizmos.color = UnityEngine.Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadius2);
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
}
