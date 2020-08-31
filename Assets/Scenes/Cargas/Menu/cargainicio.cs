using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cargainicio : MonoBehaviour
{
    private float contador = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contador = contador + Time.deltaTime;
        if (Input.anyKeyDown) SceneManager.LoadScene("CargaPostInicio");
        if (contador > 15) SceneManager.LoadScene("CargaPostInicio");
    }
}
