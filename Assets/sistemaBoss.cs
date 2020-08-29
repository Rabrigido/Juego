using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sistemaBoss : MonoBehaviour
{
    public GameObject detector;
    public GameObject bloqueo;
    public GameObject barraVida;
    public int vidaJefe;
    public GameObject barragris;
    public GameObject barranegra;
    public GameObject nombrejefe;
    public GameObject fondojefe;

    // Start is called before the first frame update
    void Start()
    {
        barraVida.SetActive(false);
        barragris.SetActive(false);
        barranegra.SetActive(false);
        nombrejefe.SetActive(false);
        fondojefe.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        barraVida.GetComponent<RectTransform>().sizeDelta = new Vector2((largoBarra()), 15);
        if (PlayerPrefs.GetInt("vidajefe") <= 0) bloqueo.SetActive(false);
    }
    private float largoBarra()
    {
        return (5*((PlayerPrefs.GetInt("vidajefe")*100) / vidaJefe));
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.gameObject.tag == "Player")
        {
            barraVida.SetActive(true);
            barragris.SetActive(true);
            barranegra.SetActive(true);
            nombrejefe.SetActive(true);
            fondojefe.SetActive(true);
        }
    }
}
