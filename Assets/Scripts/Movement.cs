using UnityEngine;

public class Movement : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float jumpForce;
    private Rigidbody2D rb;
    private bool isJumping;

    public void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D> ();
        isJumping = false;
    }

    private void Move ()
    {
        float horizontal_movement = Input.GetAxis ("Horizontal");
        Vector2 movement = new Vector2 (horizontal_movement, 0.0f);
        if (rb.velocity.magnitude <= maxSpeed)
        {
            rb.AddForce (movement * acceleration);
        }
    }

    public void Update ()
    {
        Move ();
 
        if (!isJumping)
        {

            if (Input.GetButton ("Jump"))
            {
                rb.AddForce (Vector2.up * jumpForce * rb.gravityScale);
                isJumping = true;
            }
        }
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isJumping = false;
        }
    }
}