using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollaider : MonoBehaviour
{
    public GameObject texto;
    public int contador = 0;



    void Start()
    {
        texto.GetComponent<Text>().text = contador.ToString();
    }
    private void Update()
    {
        contador = Int32.Parse(texto.GetComponent<Text>().text);
    }

    private void OnTriggerEnter2D(Collider2D colission)
    {
        if(colission.gameObject.tag == "Player")
        {
            contador++;
            texto.GetComponent<Text>().text = contador.ToString();
            gameObject.SetActive(false);
        }
        
    }
}
