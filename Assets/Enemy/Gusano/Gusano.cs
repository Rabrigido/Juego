using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gusano : MonoBehaviour
{
    // Variables para gestionar el radio de vision y velocidad
    public float visionRadius1;
    public float visionRadius2;
    public float speed;
    public float speed2;
    public GameObject player;
    private Boolean exploto = false;
    private Boolean caminando = false;

    private AudioSource sonido;
    public AudioClip baba;
    Vector3 target;

    public GameObject audioExplosionGusano;


    void Start()
    {
        sonido = gameObject.GetComponent<AudioSource>();
        target = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Animator>().GetBool("Ver") && !caminando)
        {
            sonido.clip = baba;
            sonido.loop = true;
            sonido.Play();
            caminando = true;
        }
        if(!gameObject.GetComponent<Animator>().GetBool("Ver"))
        {
            sonido.Stop();
            caminando = false;
        }

        if (!gameObject.GetComponent<Animator>().GetBool("Explosion") && !exploto)
        {
            target = new Vector3(player.gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            float dist = Vector3.Distance(target, transform.position);

            if (dist < visionRadius1 && PlayerPrefs.GetInt("Vida") > 0)
            {
                gameObject.GetComponent<Animator>().SetBool("Explosion", true);

            }
            if(dist < visionRadius2 && PlayerPrefs.GetInt("Vida") > 0)
            {
                if (gameObject.transform.position.x - player.transform.position.x > 0)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                if (gameObject.transform.position.x - player.transform.position.x < 0)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
                
                gameObject.GetComponent<Animator>().SetBool("Ver", true);

                float fixedSpeed = speed * Time.deltaTime;

                transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

            }

            if(dist > visionRadius2)
            {
                gameObject.GetComponent<Animator>().SetBool("Ver", false);

            }
        }
        else if(gameObject.GetComponent<Animator>().GetBool("Explosion") && !exploto)
        {
            gameObject.GetComponent<Animator>().SetBool("Explosion", false);
            Destroy(Instantiate(audioExplosionGusano, gameObject.transform.position, Quaternion.identity),0.4f);
            Destroy(gameObject, .5f);
            exploto = true;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius1);
        Gizmos.color = UnityEngine.Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadius2);
    }
    
}