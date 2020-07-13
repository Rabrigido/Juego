using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    
    public float bulletSpeed;
    public float bulletLife;
    public string tag;
    private GameObject gun;
    private GameObject player;

    private Rigidbody2D bulletRB;
    private float originalScaleX;
    // Start is called before the first frame update

    void Awake()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        gun = GameObject.FindGameObjectWithTag(tag);
        player = GameObject.FindGameObjectWithTag(tag);
        originalScaleX = transform.localScale.x;

    }

    void Start()
    {
        if (player.GetComponent<SpriteRenderer>().flipX)
        {
            transform.localScale = new Vector3(-originalScaleX, transform.localScale.y, transform.localScale.z);
            bulletRB.velocity = new Vector2(-bulletSpeed, bulletRB.velocity.y);
        }
        else if(!player.GetComponent<SpriteRenderer>().flipX)
        {
            transform.localScale = new Vector3(originalScaleX, transform.localScale.y, transform.localScale.z);
            bulletRB.velocity = new Vector2(bulletSpeed, bulletRB.velocity.y);

        }

    }

    // Update is called once per frame
    void Update()
    {
       
        Destroy(gameObject, bulletLife);
    }
}
