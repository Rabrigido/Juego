using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollaider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colission)
    {
        gameObject.SetActive(false);
    }
}
