using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazones : MonoBehaviour
{

    public GameObject corazon;
    public GameObject corazon1;
    public GameObject corazon2;
    public GameObject corazon3;
    public int vida = 4;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerLife>().getVida() == 3)
        {
            corazon.SetActive(false);
        }
        if (player.GetComponent<PlayerLife>().getVida() == 2)
        {
            corazon1.SetActive(false);
        }
        if (player.GetComponent<PlayerLife>().getVida() == 1)
        {
            corazon2.SetActive(false);
        }
        if (player.GetComponent<PlayerLife>().getVida() == 0)
        {
            corazon3.SetActive(false);

        }
    }
}
