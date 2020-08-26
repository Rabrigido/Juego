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
    public int option;
    public GameObject player;
    private bool exploto = false;

    private bool devolviendose;

    //Variable para guardar la posicion
    //GameObject player;
    //Variable para guardar la posicion inicial
    Vector3 initialPosition;
    Vector3 target;


    public AudioClip audioAtaque;
    private AudioSource fuenteAudio;


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
        if (!gameObject.GetComponent<Animator>().GetBool("Explosion") && !exploto)
        {
            target = player.gameObject.transform.position;
            float dist = Vector3.Distance(player.transform.position, transform.position);

            if (dist < visionRadius1 && PlayerPrefs.GetInt("Vida") > 0)
            {
                gameObject.GetComponent<Animator>().SetBool("Explosion", true);

                if (dist < visionRadius1 && PlayerPrefs.GetInt("Vida") > 0)
                {
                    int vida = PlayerPrefs.GetInt("Vida");
                    vida--;
                    PlayerPrefs.SetInt("Vida", vida);

                }
            }
            Debug.Log(dist);
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
                player.GetComponent<Animator>().SetBool("Ver", false);

            }
        }
        else if(gameObject.GetComponent<Animator>().GetBool("Explosion") && !exploto)
        {
            gameObject.GetComponent<Animator>().SetBool("Explosion", false);
            Destroy(gameObject, 1);
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