using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public int vida = 4;
    public int numeroEscenaSiguiente;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name);

        if (SceneManager.GetActiveScene().name.Equals("Nivel2.1"))
        {
            PlayerPrefs.SetInt("Vida", 4);
        }
        else
        {
            vida = PlayerPrefs.GetInt("Vida");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (vida == 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Muerte", true);
            if (PlayerPrefs.GetInt("NumeroJugadores") == 2)  //Hay 2 player
            {
                if (PlayerPrefs.GetInt("PlayerActual") == 1)  //Se murio el primero de los 2
                {
                    PlayerPrefs.SetInt("ModoMuerte", 2); // te carrea tu pana uwu
                }
                if (PlayerPrefs.GetInt("PlayerActual") == 2) //Se murio el segundo de los 2
                {
                    PlayerPrefs.SetInt("ModoMuerte", 1); // pal lobby, F
                }
            }
            if (PlayerPrefs.GetInt("NumeroJugadores") == 1)  //Hay 1 player
            {
                PlayerPrefs.SetInt("ModoMuerte", 1); //pal lobby, F
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "garra")
        {
            if (vida > 0)
            {
                vida--;
                PlayerPrefs.SetInt("Vida", vida);
            }

        }

    }
    public int getVida()
    {
        return vida;
    }
}