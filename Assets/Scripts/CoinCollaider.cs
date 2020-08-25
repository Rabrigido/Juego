using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollaider : MonoBehaviour
{
    public GameObject texto;
    public int contador;
    public GameObject audioRecolectable;

    private void OnTriggerEnter2D(Collider2D colission)
    {
        if(colission.gameObject.tag == "Player")
        {
            contador = PlayerPrefs.GetInt("contadorRec");
            contador++;
            PlayerPrefs.SetInt("contadorRec", contador);
            Debug.Log(contador);
            texto.GetComponent<Text>().text = contador.ToString();
            Instantiate(audioRecolectable, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
