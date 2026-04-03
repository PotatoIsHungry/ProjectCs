using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    float horizontalInput;
    float movementSpeed = 10f;
    bool isFacingRight = false;
    float jumpPower = 23f;
    bool isJumping = false;
    private float jumpTimer;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = 0;
        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed)
                horizontalInput = -1f;
            if (Keyboard.current.dKey.isPressed)
                horizontalInput = 1f;
        }

        flipSprite();

        if ((Keyboard.current.spaceKey.isPressed || Keyboard.current.wKey.isPressed) && !isJumping)
        {
            if (jumpTimer >= 0.95)
            {
                jumpTimer = 0;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
                isJumping = true;
            }

        }

        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * .8f * Time.deltaTime;
        }

        jumpTimer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * movementSpeed, rb.linearVelocity.y);
    }

    void flipSprite()
    {
        if ((isFacingRight && horizontalInput < 0f) || (!isFacingRight && horizontalInput > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x = ls.x * -1f;
            transform.localScale = ls;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
