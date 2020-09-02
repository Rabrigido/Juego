using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaPostInicio : MonoBehaviour
{
    private float contador = 0;
    public GameObject cargando;
    // Start is called before the first frame update
    void Start()
    {
        cargando.SetActive(false);
        PlayerPrefs.SetInt("Vida", 4);
    }

    // Update is called once per frame
    void Update()
    {
        contador = contador + Time.deltaTime;
        if (contador >=27) cargando.SetActive(true);
        if (Input.anyKeyDown) SceneManager.LoadScene("MenuPrincipal");
        if (contador>30) SceneManager.LoadScene("MenuPrincipal");
    }
}
