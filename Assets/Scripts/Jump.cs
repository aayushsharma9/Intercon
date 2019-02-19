using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpIncrements;
    public float jumpImpulse;
    public float jumpDuration;
    private Rigidbody2D rb;
    private bool isJumping, isGrounded;
    private float t;

    public void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D> ();
        isJumping = false;
        t = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Jumppad")
        {
            rb.AddForce(Vector2.up * 1000);
            Debug.Log("JUMPAD");
            isJumping = true;
        }
    }
    void FixedUpdate ()
    {
        if (isGrounded && Input.GetButton ("Jump"))
        {
            rb.AddForce (Vector2.up * jumpImpulse * rb.gravityScale);
            isJumping = true;
            isGrounded = false;
            t = 0;
        }

        if (Input.GetButton ("Jump") && isJumping && t <= jumpDuration)
        {
            rb.AddForce (Vector2.up * jumpIncrements * rb.gravityScale);
            t += Time.deltaTime;
        }

        if (Input.GetButtonUp ("Jump"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Jumppad")
        {
            isGrounded = true;
        }   
    }

    private void OnCollisionExit2D (Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }
}