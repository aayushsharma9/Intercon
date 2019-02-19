using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce, ringSpawnInterval;
    public GameObject RingObject;
    private Rigidbody2D rb;
    private float t;

    private void Start ()
    {
        t = 0;
    }

    private void Update ()
    {
        t += Time.deltaTime;

        if (t >= ringSpawnInterval)
        {
            Instantiate (RingObject, transform.position, Quaternion.identity);
            t = 0;
        }
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb = other.gameObject.GetComponent<Rigidbody2D> ();
            rb.AddForce (Vector2.up * jumpForce * rb.gravityScale);
        }
    }

}