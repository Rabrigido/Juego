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


    private bool fire;
    private Animator shot;


    // Start is called before the first frame update
    void Start()
    {
        shot = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        shot.SetBool("Shot", fire);
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

        if (Input.GetKey("d") && Input.GetKey("c"))
        {
            gameObject.transform.Translate(run_Speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a") && Input.GetKey("c"))
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
    public void PlayerShooting()
    {
        if (Input.GetKeyDown("space") && !Input.GetKey("s") && !gameObject.GetComponent<SpriteRenderer>().flipX && !Input.GetKey("a") && !Input.GetKey("d"))
        {
            Vector3 posisionArreglada = new Vector3(bullet.position.x + 2f, bullet.position.y + .8f, bullet.position.x);
            Instantiate(bulletPrefab, posisionArreglada , bullet.rotation);
        }
        else if (Input.GetKeyDown("space") && !Input.GetKey("s") && gameObject.GetComponent<SpriteRenderer>().flipX && !Input.GetKey("a") && !Input.GetKey("d"))
        {
            Vector3 posisionArreglada = new Vector3(bullet.position.x -2f, bullet.position.y + .8f, bullet.position.x);
            Instantiate(bulletPrefab, posisionArreglada, bullet.rotation);
        }
        else if (Input.GetKeyDown("space") && !Input.GetKey("s") && !gameObject.GetComponent<SpriteRenderer>().flipX && !Input.GetKey("a") && Input.GetKey("d"))
        {
            Vector3 posisionArreglada = new Vector3(bullet.position.x + 2f, bullet.position.y + .3f, bullet.position.x);
            Instantiate(bulletPrefab, posisionArreglada, bullet.rotation);
        }
        else if (Input.GetKeyDown("space") && !Input.GetKey("s") && gameObject.GetComponent<SpriteRenderer>().flipX && Input.GetKey("a") && !Input.GetKey("d"))
        {
            Vector3 posisionArreglada = new Vector3(bullet.position.x - 2f, bullet.position.y + .3f, bullet.position.x);
            Instantiate(bulletPrefab, posisionArreglada, bullet.rotation);
        }
        else if (Input.GetKeyDown("space") && Input.GetKey("s") && !gameObject.GetComponent<SpriteRenderer>().flipX )
        {
            Vector3 posisionArreglada = new Vector3(bullet.position.x + 2f, bullet.position.y - .5f, bullet.position.x);
            Instantiate(bulletPrefab, posisionArreglada, bullet.rotation);
        }
        else if (Input.GetKeyDown("space") && Input.GetKey("s") && gameObject.GetComponent<SpriteRenderer>().flipX )
        {
            Vector3 posisionArreglada = new Vector3(bullet.position.x - 2f, bullet.position.y - .5f, bullet.position.x);
            Instantiate(bulletPrefab, posisionArreglada, bullet.rotation);
        }
    }
    public float getWalkSpeed()
    {
        return walk_Speed;
    }

 
  
    
}
