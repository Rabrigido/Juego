using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int vida = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida == 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Muerte", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(vida > 0)
            {
                vida--;
            }
            
        }

    }
    public int getVida()
    {
        return vida;
    }
}
