using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    private int boolean = -1;
    public GameObject fondo;
    public GameObject titulo;
    public GameObject menu;
    public GameObject continuar;
    public GameObject seguro;
    public GameObject camara;
    public GameObject player;
    public GameObject si;
    public GameObject no;
    private bool muted;

    // Start is called before the first frame update
    void Start()
    {
        fondo.SetActive(false);
        titulo.SetActive(false);
        menu.SetActive(false);
        continuar.SetActive(false);
        si.SetActive(false);
        no.SetActive(false);
        seguro.SetActive(false);
        mutear(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Vida") != 0)
        {
            if (Input.GetKeyDown("escape"))
            {
                boolean = boolean * -1;
            }
            if (boolean == 1)
            {
                player.GetComponent<Player1controller>().enabled = false;
                mutear(true);
                Time.timeScale = 0;
                fondo.SetActive(true);
                titulo.SetActive(true);
                menu.SetActive(true);
                continuar.SetActive(true);
            }
            if (boolean == -1)
            {
                player.GetComponent<Player1controller>().enabled = true;
                mutear(false);
                fondo.SetActive(false);
                titulo.SetActive(false);
                menu.SetActive(false);
                continuar.SetActive(false);
                si.SetActive(false);
                no.SetActive(false);
                seguro.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
    public void menuP()
    {
        menu.SetActive(false);
        continuar.SetActive(false);
        seguro.SetActive(true);
        si.SetActive(true);
        no.SetActive(true);
    }
    public void Si()
    {
        mutear(false);
        SceneManager.LoadScene("MenuPrincipal");
        
    }
    public void No()
    {
        si.SetActive(false);
        no.SetActive(false);
        seguro.SetActive(false);
        menu.SetActive(true);
        continuar.SetActive(true);
    }
    public void Continuar()
    {
        boolean = -1;
    }

    private void mutear(bool mute)
    {
        AudioSource[] sources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        for (int index = 0; index < sources.Length; ++index)
        {
            sources[index].mute = mute;
        }
        muted = mute;
    }
}
