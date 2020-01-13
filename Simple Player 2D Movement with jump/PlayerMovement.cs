using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 playerMov;
    public bool isGrounded;
    public Vector2 jumpForce;
    public bool facingRight;

    private Rigidbody2D rb2d;        

    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
       Movement();
    }


     void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Flip(horizontal);
        if (Input.GetKey("d"))
        {
            rb2d.AddForce(playerMov);
        }
        if (Input.GetKey("a"))
        {
            rb2d.AddForce(-playerMov);
        }
        if (Input.GetKey("w") && isGrounded)
        {
            rb2d.AddForce(jumpForce);
            isGrounded = false;
        }

    }
    void Flip(float horizontal)
    {
        if (horizontal < 0 && !facingRight || horizontal > 0 && facingRight)
        {
            facingRight = !facingRight;

            transform.Rotate(0f, 180f, 0f);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
