﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject Nex;

    private void Update ()
    {
        if (Nex)
        {
            this.transform.position = Nex.transform.position;
        }
    }
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player" && other.gameObject != Nex)
        {
            Debug.Log ("WIN!");
        }
    }
}