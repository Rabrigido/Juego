using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nombrs : MonoBehaviour
{
    public InputField Entrada1;
    public InputField Entrada2;
    private string nombre1;
    private string nombre2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ok()
    {
        if (PlayerPrefs.GetInt("NumeroJugadores") == 1)
        {
            nombre1 = Entrada1.text;
            PlayerPrefs.SetString("Nombre1", nombre1);
        }
        else if (PlayerPrefs.GetInt("NumeroJugadores") == 2)
        {
            nombre1 = Entrada1.text;
            nombre2 = Entrada2.text;
            PlayerPrefs.SetString("Nombre1", nombre1);
            PlayerPrefs.SetString("Nombre2", nombre2);
        }
    }
}
