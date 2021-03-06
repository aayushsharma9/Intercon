﻿using UnityEngine;

public class Movement : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    private Rigidbody2D rb;

    public void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D> ();
    }

    private void Move ()
    {
        float horizontal_movement = Input.GetAxis ("Horizontal");
        Vector2 movement = new Vector2 (horizontal_movement * acceleration, 0);
        // rb.AddForce (movement, ForceMode2D.Force);
        rb.velocity += movement * Time.deltaTime;
    }

    public void FixedUpdate ()
    {
        Move ();
    }
}