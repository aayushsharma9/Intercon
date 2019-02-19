using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpIncrements;
    public float jumpImpulse;
    public float jumpDuration;
    private Rigidbody2D rb;
    private bool isJumping, canJump;
    private float t;

    public void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D> ();
        isJumping = false;
        t = 0;
    }

    void FixedUpdate ()
    {
        if (canJump && Input.GetButton ("Jump"))
        {
            rb.AddForce (Vector2.up * jumpImpulse * rb.gravityScale);
            isJumping = true;
            canJump = false;
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
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "JumpPad")
        {
            canJump = true;
            //Debug.Log ("triggered by " + other.gameObject.tag);
        }
    }

    private void OnCollisionExit2D (Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            canJump = false;
        }
    }
}