using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    private bool isJumping;
    private float t;
    Rigidbody2D rb;

    private void Start()
    {
        Debug.Log(rb);
        isJumping = false;
        t = 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            rb = other.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * 1000);
        }
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(Vector2.up * 1000);
            Debug.Log("YELLO");
            isJumping = true;
        }
    }
}
