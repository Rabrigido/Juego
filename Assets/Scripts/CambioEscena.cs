using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambioEscena : MonoBehaviour
{

    public string nombreEscena;
    public GameObject TextoContadorCarpetas;
    public GameObject textoContadorAlien;
    public int totalRecolectable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (TextoContadorCarpetas.GetComponent<Text>().text.Equals(totalRecolectable.ToString()))
            {
                if (textoContadorAlien.GetComponent<Text>().text.Equals("0"))
                {
                    SceneManager.LoadScene(nombreEscena, LoadSceneMode.Single);
                }
                else 
                {
                    Debug.Log("te faltan enemigos");
                }       
            }
            else {
                Debug.Log("te faltan items");
            }     
        } 
    }
}
