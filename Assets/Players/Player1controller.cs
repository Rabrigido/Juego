using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {
            gameObject.transform.Translate(-10f * Time.deltaTime, 0, 0);
            gameObject.GetComponent<Animator>().SetBool("Move", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey("right"))
        {
            gameObject.transform.Translate(10f * Time.deltaTime, 0, 0);
            gameObject.GetComponent<Animator>().SetBool("Move", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (!Input.GetKey("right") && !Input.GetKey("left"))
        {
            gameObject.GetComponent<Animator>().SetBool("Move", false);
            gameObject.GetComponent<Animator>().SetBool("Move", false);

        }
    }
}
