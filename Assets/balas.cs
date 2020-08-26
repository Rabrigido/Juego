using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balas : MonoBehaviour
{
    public GameObject bala1;
    public GameObject bala2;
    public GameObject bala3;
    public GameObject bala4;
    public GameObject bala5;
    public GameObject bala6;
    private int contador = 6;
    private float contadorAlt;
    public GameObject recargando;
    public GameObject player;
    private Boolean muerto;
    public GameObject audioRecargando1;
    public GameObject audioRecargando2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        muerto = player.GetComponent<Animator>().GetBool("Muerte");
        if (contador >= 0 && !muerto)
        {
            if (Input.GetKeyDown("r") && contador != 6)
            {
                contador = 0;
            }
            if (Input.GetKeyDown("space") && !Input.GetKey("s"))
            {
                contador--;
            }
        }
        if (contador == 6)
        {
            recargando.SetActive(false);
            PlayerPrefs.SetInt("disparo", 1);
            contadorAlt = 0;
            bala1.SetActive(true);
            bala2.SetActive(true);
            bala3.SetActive(true);
            bala4.SetActive(true);
            bala5.SetActive(true);
            bala6.SetActive(true);
        }
        if (contador == 5)
        {
            bala1.SetActive(true);
            bala2.SetActive(true);
            bala3.SetActive(true);
            bala4.SetActive(true);
            bala5.SetActive(true);
            bala6.SetActive(false);
        }
        if (contador == 4)
        {
            bala1.SetActive(true);
            bala2.SetActive(true);
            bala3.SetActive(true);
            bala4.SetActive(true);
            bala5.SetActive(false);
            bala6.SetActive(false);
        }
        if (contador == 3)
        {
            bala1.SetActive(true);
            bala2.SetActive(true);
            bala3.SetActive(true);
            bala4.SetActive(false);
            bala5.SetActive(false);
            bala6.SetActive(false);
        }
        if (contador == 2)
        {
            bala1.SetActive(true);
            bala2.SetActive(true);
            bala3.SetActive(false);
            bala4.SetActive(false);
            bala5.SetActive(false);
            bala6.SetActive(false);
        }
        if (contador == 1)
        {
            bala1.SetActive(true);
            bala2.SetActive(false);
            bala3.SetActive(false);
            bala4.SetActive(false);
            bala5.SetActive(false);
            bala6.SetActive(false);
        }
        if (contador == 0)
        {
            
            bala1.SetActive(false);
            bala2.SetActive(false);
            bala3.SetActive(false);
            bala4.SetActive(false);
            bala5.SetActive(false);
            bala6.SetActive(false);
        }
        if (contador <= 0)
        {
           
            recargando.SetActive(true);
            PlayerPrefs.SetInt("disparo", contador);
            contadorAlt = contadorAlt + Time.deltaTime;
            if(contadorAlt > 0.02f && contadorAlt < 0.03f)
            {
                Destroy(Instantiate(audioRecargando1, gameObject.transform.position, Quaternion.identity),3);

            }
            if (contadorAlt > 3)
            {
                contador = 6;//contador alt son los segundos de recarga
                Destroy(Instantiate(audioRecargando2, gameObject.transform.position, Quaternion.identity),3);
            }
        }
    }
}
