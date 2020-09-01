using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultado : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Text>().text = "Puntaje = " + PlayerPrefs.GetInt("PuntajeTotal");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
