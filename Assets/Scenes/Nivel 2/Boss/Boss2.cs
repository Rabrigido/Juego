using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Boss2 : MonoBehaviour
{
    public float visionRadius1;
    public float visionRadius2;
    public GameObject player;
    Vector3 target;
    private float contador;
    private float contador2;
    public float speed;
    private int number;
    private float speed2;
    private static readonly Random getrandom = new Random();

    // Start is called before the first frame update
    void Start()
    {
        target = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        float dist = Vector3.Distance(player.transform.position, transform.position);
        target = new Vector3(player.transform.position.x, gameObject.transform.position.y, 0f);
        if (!gameObject.GetComponent<Animator>().GetBool("death"))
        {
            if (player.transform.position.x < gameObject.transform.position.x)
            {
                gameObject.transform.localScale = new Vector3(-7, 7, 7);
            }
            if (player.transform.position.x > gameObject.transform.position.x)
            {
                gameObject.transform.localScale = new Vector3(7, 7, 7);
            }
            if(dist < visionRadius1)
            {
                
                gameObject.GetComponent<Animator>().SetBool("smell", true);
                contador += Time.deltaTime;
                if(contador > 2)
                {
                    gameObject.GetComponent<Animator>().SetBool("smell", false);
                    gameObject.GetComponent<Animator>().SetBool("move", true);
                    
                    if (gameObject.transform.position.x == player.transform.position.x)
                    {
                        contador2 += Time.deltaTime;
                        gameObject.GetComponent<Animator>().SetBool("smell", true);
                        gameObject.GetComponent<Animator>().SetBool("move", false);
                        speed2 = 0;
                    }
                    if (dist <= visionRadius2)
                    {
                        int number = GetRandomNumber(1, 6);
                        if (number == 1)
                        {
                            speed2 = 0;
                            transform.position = Vector3.MoveTowards(transform.position, target, speed2);
                            gameObject.GetComponent<Animator>().SetBool("ataqueCola", false);
                            gameObject.GetComponent<Animator>().SetBool("ataqueGarra", true);
                            gameObject.GetComponent<Animator>().SetBool("smell", false);
                            gameObject.GetComponent<Animator>().SetBool("move", false);
                        }
                        else if(number == 2)
                        {
                            speed2 = 0;
                            transform.position = Vector3.MoveTowards(transform.position, target, speed2);
                            gameObject.GetComponent<Animator>().SetBool("ataqueGarra", false);
                            gameObject.GetComponent<Animator>().SetBool("ataqueCola", true);
                            gameObject.GetComponent<Animator>().SetBool("smell", false);
                            gameObject.GetComponent<Animator>().SetBool("move", false);
                        }
                    }
                    if (dist > visionRadius2)
                    {
                        gameObject.GetComponent<Animator>().SetBool("ataqueGarra", false);
                        gameObject.GetComponent<Animator>().SetBool("ataqueCola", false);
                        speed2 = speed * Time.deltaTime;
                        gameObject.GetComponent<Animator>().SetBool("move", true);
                        transform.position = Vector3.MoveTowards(transform.position, target, speed2);
                    }
                    speed2 = speed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, target, speed2);
                }
            }
            else
            {
                GetComponent<Animator>().SetBool("move", false);
                GetComponent<Animator>().SetBool("smell", false);
                GetComponent<Animator>().SetBool("ataqueCola", false);
                GetComponent<Animator>().SetBool("ataqueGarra", false);
                contador = 0;
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
    private static int GetRandomNumber(int min, int max)
    {
        lock (getrandom)
        {
            return getrandom.Next(min, max);
        }
    }
}
