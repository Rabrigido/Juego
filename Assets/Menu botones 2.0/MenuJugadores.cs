using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuJugadores : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void unJugador()
    {
        PlayerPrefs.SetInt("NumeroJugadores", 1);
        PlayerPrefs.SetInt("PlayerActual", 1);
        SceneManager.LoadScene("cargaMenuN1.1");
    }
    public void dosJugadores()
    {
        PlayerPrefs.SetInt("NumeroJugadores", 2);
        PlayerPrefs.SetInt("PlayerActual", 1);
        SceneManager.LoadScene("cargaMenuN1.1");
    }
    public void volver()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void comoJugar()
    {
        SceneManager.LoadScene("comoJugar");
    }
    public void reiniciar()
    {
        PlayerPrefs.SetString("DatosNombres", "");
        PlayerPrefs.SetString("DatosPuntajes", "");
        SceneManager.LoadScene("Ranking");

    }
}
