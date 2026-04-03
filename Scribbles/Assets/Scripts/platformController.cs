using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class platformController : MonoBehaviour
{
    private Collider2D platformCollider;
    private Collider2D playerCollider;

    private bool isOnPlatform = false;

    void Start()
    {
        platformCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (isOnPlatform && playerCollider != null && Keyboard.current.shiftKey.wasPressedThisFrame)
        {
            StartCoroutine(DisableCollision());
            
        }
    }

    private IEnumerator DisableCollision()
    {
        Physics2D.IgnoreCollision(platformCollider, playerCollider, true);
        yield return new WaitForSeconds(0.5f);

        Physics2D.IgnoreCollision(platformCollider, playerCollider, false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOnPlatform = true;
            playerCollider = collision.collider;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOnPlatform = false;   
        }
    }
}