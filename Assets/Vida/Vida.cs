using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D colission)
    {
        if (colission.gameObject.tag == "Player" && PlayerPrefs.GetInt("Vida") < 4)
        {


            gameObject.SetActive(false);

        }

    }
}
