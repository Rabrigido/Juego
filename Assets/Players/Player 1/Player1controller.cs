using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1controller : MonoBehaviour
{
    public float jump_Force;
    public float walk_Speed;
    public float run_Speed;
    public bool onGround;
    public Transform footRefLeft;
    public Transform footRef;
    public Transform footRefRight;
    public GameObject gun;
    public float disparo;
    public Transform bullet;
    public GameObject bulletPrefab;
    private Boolean muerto;
    public AudioClip audioCaminar;
    private AudioSource fuenteAudio;
    private Boolean caminandoA;

    private bool fire;
    private Animator shot;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("contadorRec", 0);
        fuenteAudio = gameObject.GetComponent<AudioSource>();
        fuenteAudio.clip = audioCaminar;
        shot = GetComponent<Animator>();
        if (PlayerPrefs.GetInt("PlayerActual") == 2) gameObject.GetComponent<Animator>().SetBool("Player2", true);
    }
    // Update is called once per frame
    void Update()
    {
        muerto = gameObject.GetComponent<Animator>().GetBool("Muerte");
        if (!muerto)
        {
            onGround = Physics2D.OverlapCircle(footRef.position, 0.5f, 1 << 8);

            // Disparo
            if (Input.GetKeyDown("space"))
            {
                PlayerShooting();
                fire = true;

            }
            else
            {
                fire = false;
            }
            //Fin Disparo

            if (gameObject.GetComponent<Animator>().GetBool("Move") && onGround)
            {
                if (!fuenteAudio.loop)
                {
                    fuenteAudio.loop = true;
                    fuenteAudio.Play();
                }

            }
            else
            {
                fuenteAudio.loop = false;
                fuenteAudio.Stop();
            }
            if (Input.GetKey("a") && (!Input.GetKey("s") || !onGround))
            {
                gameObject.transform.Translate(-walk_Speed * Time.deltaTime, 0, 0);
                gameObject.GetComponent<Animator>().SetBool("Move", true);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;

            }

            if (Input.GetKey("d") && (!Input.GetKey("s") || !onGround))
            {
                gameObject.transform.Translate(walk_Speed * Time.deltaTime, 0, 0);
                gameObject.GetComponent<Animator>().SetBool("Move", true);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;

            }

            if (Input.GetKey("s"))
            {
                gameObject.GetComponent<Animator>().SetBool("Crouch", true);
                gameObject.GetComponent<Animator>().SetBool("Move", false);
                gameObject.GetComponent<Animator>().SetBool("Jump", false);
            }
            if (!Input.GetKey("s"))
            {
                gameObject.GetComponent<Animator>().SetBool("Crouch", false);
            }

            if (Input.GetKey("s") && Input.GetKey("a"))
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }

            if (Input.GetKey("s") && Input.GetKey("d"))
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }

            if ((!Input.GetKey("d") && !Input.GetKey("a")) || (Input.GetKey("d") && Input.GetKey("a")))
            {
                gameObject.GetComponent<Animator>().SetBool("Move", false);
            }

            if (Input.GetKey("d") && Input.GetKey("left shift") && !Input.GetKey("s"))
            {
                gameObject.transform.Translate(run_Speed * Time.deltaTime, 0, 0);
            }

            if (Input.GetKey("a") && Input.GetKey("left shift") && !Input.GetKey("s"))
            {
                gameObject.transform.Translate(-run_Speed * Time.deltaTime, 0, 0);
            }

            if (Input.GetKeyDown("w") && onGround && !Input.GetKey("s"))
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump_Force));

            }

            if (!onGround && !Input.GetKey("s"))
            {
                gameObject.GetComponent<Animator>().SetBool("Jump", true);
            }

            if (onGround)
            {
                gameObject.GetComponent<Animator>().SetBool("Jump", false);
            }

        }
    }
    public void PlayerShooting()
    {
        if (PlayerPrefs.GetInt("disparo") >= 0)
        {
            if (Input.GetKeyDown("space") && !Input.GetKey("s") && !gameObject.GetComponent<SpriteRenderer>().flipX && !Input.GetKey("a") && !Input.GetKey("d"))
            {
                Vector3 posisionArreglada = new Vector3(bullet.position.x + 2f, bullet.position.y + .8f, bullet.position.x);
                Instantiate(bulletPrefab, posisionArreglada, bullet.rotation);
            }
            else if (Input.GetKeyDown("space") && !Input.GetKey("s") && gameObject.GetComponent<SpriteRenderer>().flipX && !Input.GetKey("a") && !Input.GetKey("d"))
            {
                Vector3 posisionArreglada = new Vector3(bullet.position.x - 2.5f, bullet.position.y + .8f, bullet.position.x);
                Instantiate(bulletPrefab, posisionArreglada, bullet.rotation);
            }
            else if (Input.GetKeyDown("space") && !Input.GetKey("s") && !gameObject.GetComponent<SpriteRenderer>().flipX && !Input.GetKey("a") && Input.GetKey("d"))
            {
                Vector3 posisionArreglada = new Vector3(bullet.position.x + 2f, bullet.position.y + .3f, bullet.position.x);
                Instantiate(bulletPrefab, posisionArreglada, bullet.rotation);
            }
            else if (Input.GetKeyDown("space") && !Input.GetKey("s") && gameObject.GetComponent<SpriteRenderer>().flipX && Input.GetKey("a") && !Input.GetKey("d"))
            {
                Vector3 posisionArreglada = new Vector3(bullet.position.x - 2.5f, bullet.position.y + .3f, bullet.position.x);
                Instantiate(bulletPrefab, posisionArreglada, bullet.rotation);
            }
            else if (Input.GetKeyDown("space") && !Input.GetKey("s") && !gameObject.GetComponent<SpriteRenderer>().flipX)
            {
                Vector3 posisionArreglada = new Vector3(bullet.position.x + 2f, bullet.position.y - .5f, bullet.position.x);
                Instantiate(bulletPrefab, posisionArreglada, bullet.rotation);
            }
            else if (Input.GetKeyDown("space") && !Input.GetKey("s") && gameObject.GetComponent<SpriteRenderer>().flipX)
            {
                Vector3 posisionArreglada = new Vector3(bullet.position.x - 2.5f, bullet.position.y - .5f, bullet.position.x);
                Instantiate(bulletPrefab, posisionArreglada, bullet.rotation);
            }
        }
    }
    public float getWalkSpeed()
    {
        return walk_Speed;
    }

 
  
    
}
