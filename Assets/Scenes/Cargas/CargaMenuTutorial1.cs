using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaMenuTutorial1 : MonoBehaviour
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
        if (Input.anyKeyDown) SceneManager.LoadScene("Nivel1.1");
        if (contador>30) SceneManager.LoadScene("Nivel1.1");
    }
}
