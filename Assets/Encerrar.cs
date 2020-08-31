using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encerrar : MonoBehaviour
{
    public GameObject player;
    private Vector3 target;
    public GameObject bloqueo;
    // Start is called before the first frame update
    void Start()
    {
        bloqueo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
       
       if (player.transform.position.x >= 680)
       {
            bloqueo.SetActive(true);
        }
      



    

    }
}
