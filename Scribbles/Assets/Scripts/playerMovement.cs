using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    float horizontalInput;
    float movementSpeed = 10f;
    float jumpPower = 23f;
    bool isJumping = false;
    private float jumpTimer;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.gravityScale = 4f;
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        

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
        if (horizontalInput > 0f)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput < 0f)
        {
            spriteRenderer.flipX = false;
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
