using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce;
    public float ringSpawnInterval;
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
            GameObject ring = Instantiate (RingObject, transform.position, transform.rotation);
            ring.transform.parent = gameObject.transform;
            t = 0;
        }
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb = other.gameObject.GetComponent<Rigidbody2D> ();
            rb.AddForce (this.transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

}