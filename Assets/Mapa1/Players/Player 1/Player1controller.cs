using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1controller : MonoBehaviour
{
    public float jumpForce;
    public bool onGround;
    public Transform footRefLeft;
    public Transform footRef;
    public Transform footRefRight;

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            gameObject.transform.Translate(-10f * Time.deltaTime, 0, 0);
            gameObject.GetComponent<Animator>().SetBool("Move", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey("d"))
        {
            gameObject.transform.Translate(10f * Time.deltaTime, 0, 0);
            gameObject.GetComponent<Animator>().SetBool("Move", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.GetKey("s"))
        {
            gameObject.GetComponent<Animator>().SetBool("Crouch", true);
        }

        if (!Input.GetKey("s"))
        {
            gameObject.GetComponent<Animator>().SetBool("Crouch", false);
        }

        if (!Input.GetKey("d") && !Input.GetKey("a"))
        {
            gameObject.GetComponent<Animator>().SetBool("Move", false);
            gameObject.GetComponent<Animator>().SetBool("Move", false);

        }

        if (Input.GetKey("d") && Input.GetKey("a"))
        {
            gameObject.GetComponent<Animator>().SetBool("Move", false);
            gameObject.GetComponent<Animator>().SetBool("Move", false);

        }

        if (Input.GetKey("d") && Input.GetKey("c"))
        {
            gameObject.transform.Translate(10f * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a") && Input.GetKey("c"))
        {
            gameObject.transform.Translate(-10f * Time.deltaTime, 0, 0);
        }

        onGround = Physics2D.OverlapCircle(footRef.position, 0.5f, 1 << 8);

        if (Input.GetKeyDown("w") && onGround && !Input.GetKey("s"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

        }

        if (!onGround)
        {
            gameObject.GetComponent<Animator>().SetBool("Jump", true);
        }

        if (onGround)
        {
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
        }

    }
}
