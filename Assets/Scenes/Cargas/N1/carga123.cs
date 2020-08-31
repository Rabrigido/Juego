using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class carga123 : MonoBehaviour
{
    private float contador = 0;
    public GameObject cargando;
    public GameObject continuar;
    // Start is called before the first frame update
    void Start()
    {
        continuar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        contador = contador + Time.deltaTime;
        if (contador > 3)
        {
            cargando.SetActive(false);
            continuar.SetActive(true);
        }
    }
    public void Continuar()
    {
        SceneManager.LoadScene("Nivel1.3");
    }
}
