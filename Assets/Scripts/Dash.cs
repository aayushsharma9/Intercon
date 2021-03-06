﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashForce;
    public float dashCooldown;
    private Rigidbody2D rb;
    private bool canDash;
    private float timer;

    private void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D> ();
        canDash = true;
    }

    void Update ()
    {
        if (!canDash)
            timer += Time.deltaTime;

        if (timer >= dashCooldown)
            canDash = true;

        float horizontal_movement = Input.GetAxis ("Horizontal");
        Vector2 movement = new Vector2 (horizontal_movement, 0.0f);

        if (canDash)
        {
            if (Input.GetButton ("Dash"))
            {
                rb.AddForce (movement * dashForce, ForceMode2D.Impulse);
                Debug.Log ("DASH!");
                canDash = false;
                timer = 0;
            }
        }
    }
}