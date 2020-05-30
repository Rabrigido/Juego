using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Movment : MonoBehaviour
{
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
        if (!Input.GetKey("d") && !Input.GetKey("a"))
        {
            gameObject.GetComponent<Animator>().SetBool("Move", false);
            gameObject.GetComponent<Animator>().SetBool("Move", false);

        }
    }
}
