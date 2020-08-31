using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garra : MonoBehaviour
{

    public float bulletSpeed;
    public float bulletLife;
    public string tagg;
    private GameObject gun;
    private GameObject boss;
    public AudioClip audioDisparo;
    public AudioSource sonido;
    
    private Rigidbody2D bulletRB;
    private float originalScaleX;



    void Awake()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        //gun = GameObject.FindGameObjectWithTag(tagg);
        boss = GameObject.FindGameObjectWithTag(tagg);
        originalScaleX = transform.localScale.x;

    }

    // Start is called before the first frame update
    void Start()
    {
        sonido = GetComponent<AudioSource>();
        sonido.clip = audioDisparo;
        sonido.loop = false;
        sonido.Play();


        if (boss.transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-originalScaleX, transform.localScale.y, transform.localScale.z);
            
            bulletRB.velocity = new Vector2(bulletSpeed, bulletRB.velocity.y);
            
        }
        else if (boss.transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(originalScaleX, transform.localScale.y, transform.localScale.z);
            bulletRB.velocity = new Vector2(-bulletSpeed, bulletRB.velocity.y);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, bulletLife);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {    
        if (collision.gameObject.tag != "Boss")
        {
            Destroy(gameObject);
        }
        

    }

}
