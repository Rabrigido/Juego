using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public float visionRadius1;
    public float visionRadius2;
    public GameObject player;
    public int initialSpeed;
    private float speed2;
    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        target = new Vector3(player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        if (!gameObject.GetComponent<Animator>().GetBool("Muerto")) //Si no está muerto
        {
            if (dist < visionRadius1) //Lo ve
            {
                
                gameObject.GetComponent<Animator>().SetBool("Acercarse", true);

                if (gameObject.transform.position.x == player.transform.position.x && 
                    gameObject.transform.position.x == player.transform.position.x) //El player está arriba del boss
                {
                    gameObject.GetComponent<Animator>().SetBool("Acercarse", false);
                    gameObject.GetComponent<Animator>().SetBool("Atacar", false);
                }

                if (dist <= visionRadius2) //Está en la distancia para atacar
                {
                    gameObject.GetComponent<Animator>().SetBool("Atacar", true);
                    speed2 = 0;
                    transform.position = Vector3.MoveTowards(transform.position, target, speed2);
                }
                if (dist > visionRadius2)  //No está tan cerca para atacar
                {
                    gameObject.GetComponent<Animator>().SetBool("Atacar", false);
                    speed2 = initialSpeed;
                    speed2 = initialSpeed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, target, speed2);
                }

                
            }
            else //No lo ve, por lo tanto no se acerca
            {
                gameObject.GetComponent<Animator>().SetBool("Acercarse", false);
            }

            if (gameObject.transform.position.x - player.transform.position.x > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            if (gameObject.transform.position.x - player.transform.position.x < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
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
