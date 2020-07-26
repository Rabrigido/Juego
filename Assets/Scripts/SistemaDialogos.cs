using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class SistemaDialogos : MonoBehaviour
{
    // Definir variables

    public TextMeshProUGUI textoD; // Es el texto que se irá escribiendo en el panel
    [TextArea(3, 15)]
    public string[] parrafos;
    int index;
    public float velocidadParrafo;

    public GameObject PanelDialogo; // Panel en el Canvas.
    public Button continuar; // Botón usado para pasar de párrafo.
    Boolean dentro; // boolean para comprobar si el player todavía se encuentra en el radio del collider.

    void Start()
    {
        // el panel de dialogo al inicio estará desactivado.

        PanelDialogo.SetActive(false);
        
    }

    // cuando el player entra en el rango del collider inicia el panel de diálogo y empieza la escritura del texto.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dentro = true;
            if (dentro)
            {
              PanelDialogo.SetActive(true);
                StartCoroutine(TextoDialogo());
            }
        }
        
    }


    // Si el player sale del collider se restauran todos las variables.
    private void OnTriggerExit2D(Collider2D collision)
    {
        dentro = false;
        index = 0;
        textoD.text = "";
        PanelDialogo.SetActive(false);
        
    }

    void Update()
    {
        // Para avanzar al siguiente parrafo se espera hasta que esté escrito todo el texto del párrafo.

        if(textoD.text == parrafos[index])
        {
            if (Input.GetKey("m"))
            {
                textoD.text = "";
                continuar.onClick.Invoke();
            }
        }
    }


    // Función de escritura del texto palabra por palabra.

    IEnumerator TextoDialogo()
    {
        foreach (char letra in parrafos[index].ToCharArray())
        {
            // Se comprueba constantemente si es que el jugador sigue dentro del rango del collider, si no es así se borrará el texto que se estaba escribiendo y dejará de escribir.
            if (dentro == false)
            {
                textoD.text = "";
                break;
            }
            else
            {
                textoD.text += letra;
                yield return new WaitForSeconds(velocidadParrafo); //tiempo que se demora en escribir letra por letra, mientras más grande el número más lenta será la escritura.
            }
        }
    }


    public void SiguienteParrafo()
    {
        // Comprobará si todavía quedan parrafos por escribir, si no es así se cerrará el panel de diálogo.

        if (index < parrafos.Length - 1)
        {
            index++; // con el index avanza al siguiente parrafo.
            textoD.text = "";
            StartCoroutine(TextoDialogo());
        }
        else
        {
            textoD.text = "";
            PanelDialogo.SetActive(false); //panel de diálogo cerrado.
        }
    }

    //textoD.text = ""; // vacié el texto que se escribe constantemente porque se enredaban las palabras, ahora ya no ocurre eso.
}
