using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class carga512 : MonoBehaviour
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
        if (contador > 3) SceneManager.LoadScene("Nivel 5.2");
    }
}
