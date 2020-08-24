using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyLife : MonoBehaviour
{

    public int cantidadBalas;
    public GameObject textoContadorEnemigos;
    private int contador;
    private Boolean muriendose;
    // Start is called before the first frame update
    float contadorRecolectable = 0;
    public GameObject recolectable;

    void Start()
    {
        if (recolectable != null)
        {
            recolectable.SetActive(false);

        }
        muriendose = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (muriendose == true)
        {

            gameObject.GetComponent<Animator>().SetBool("vePlayer", false);
            gameObject.GetComponent<Animator>().SetBool("Atacando", false);
            gameObject.GetComponent<Animator>().SetBool("Muerto", true);
            Destroy(gameObject, 1.5f);


        }
        if (cantidadBalas == 0 && muriendose == false)
        {
            muriendose = true;
            contador = Int32.Parse(textoContadorEnemigos.GetComponent<Text>().text);
            contador--;
            textoContadorEnemigos.GetComponent<Text>().text = contador.ToString();


        }
        if (gameObject.GetComponent<Animator>().GetBool("Muerto") && recolectable != null)
        {
            
            contadorRecolectable = contadorRecolectable + Time.deltaTime;
            if (contadorRecolectable > 1.4)
            {
                recolectable.transform.position = gameObject.transform.position;
                recolectable.SetActive(true);
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.gameObject.tag == "Bala")
        {
            cantidadBalas--;
        }
    }
}