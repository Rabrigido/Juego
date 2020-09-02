using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    private static bool created = false;
    private static bool reproduciendo = false;

    public AudioClip tema1;
    public AudioClip tema2;
    public AudioClip tema3;
    public AudioClip tema4;
    public AudioClip tema5;
    public AudioClip temaBoss;
    public AudioClip temaMuerte;
    public AudioClip temaMenu;
    public AudioClip temaPutin;



    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            desmutear();
        }
        if (PlayerPrefs.GetInt("Vida") <= 0 && !reproduciendo)
        {
            GetComponent<AudioSource>().clip = temaMuerte;
            reproduciendo = true;
        }
        if (SceneManager.GetActiveScene().name.Equals("Nivel1.1")) GetComponent<AudioSource>().clip = tema1;

        if (SceneManager.GetActiveScene().name.Equals("Nivel1.5") || (SceneManager.GetActiveScene().name.Equals("Nivel2.5"))
            || (SceneManager.GetActiveScene().name.Equals("Nivel3.5")) || (SceneManager.GetActiveScene().name.Equals("Nivel4.6"))
           || (SceneManager.GetActiveScene().name.Equals("Nivel5.5"))) GetComponent<AudioSource>().clip = temaBoss;

        if (SceneManager.GetActiveScene().name.Equals("Nivel2.1")) GetComponent<AudioSource>().clip = tema2;
        if (SceneManager.GetActiveScene().name.Equals("Nivel3.1")) GetComponent<AudioSource>().clip = tema3;
        if (SceneManager.GetActiveScene().name.Equals("Nivel4.1")) GetComponent<AudioSource>().clip = tema4;
        if (SceneManager.GetActiveScene().name.Equals("Nivel5.1")) GetComponent<AudioSource>().clip = tema5;
        if (SceneManager.GetActiveScene().name.Equals("MenuPrincipal")) GetComponent<AudioSource>().clip = temaMenu;
        if (SceneManager.GetActiveScene().name.Equals("Ranking")) GetComponent<AudioSource>().clip = temaPutin;
        if (SceneManager.GetActiveScene().name.Equals("Creditos")) GetComponent<AudioSource>().Stop();
        if (SceneManager.GetActiveScene().name.Equals("Final")) GetComponent<AudioSource>().Stop();
        if (SceneManager.GetActiveScene().name.Equals("Nivel6.1")) GetComponent<AudioSource>().clip = temaMenu;
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
        

    }

    public void desmutear()
    {
        AudioSource[] sources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        for (int index = 0; index < sources.Length; ++index)
        {
            if (sources[index].clip != null)
            {
                {
                    sources[index].mute = false;
                }
            }
        }
    }
}
