﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public Transform from;
    public Transform to;

   void OnDrawGizmos()
    {
        if(from != null && to != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(from.position, to.position);
            Gizmos.DrawSphere(from.position, 0.15f);
            Gizmos.DrawSphere(to.position, 0.15f);
        }
    }
}
