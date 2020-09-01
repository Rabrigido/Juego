using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptFinal : MonoBehaviour
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
        if (Input.anyKeyDown) SceneManager.LoadScene("Nivel6.1");
        if (contador > 32) SceneManager.LoadScene("Nivel6.1");
    }
}
