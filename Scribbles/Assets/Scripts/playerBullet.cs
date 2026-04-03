using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Rendering;

public class playerShooting : MonoBehaviour
{
    private float speed = 4f;

    private float direction = 1;
    private float rotationSpeed = 360f;
    public int damage = 50;
    private float timer;
    public void SetDirection(float dir)
    {
        direction = dir;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * direction * speed * Time.deltaTime, Space.World);

        timer += Time.deltaTime;

        if (timer > 10)
        {
            Destroy(gameObject);
        }

        // Rotation stays the same
        transform.Rotate(0f, 0f, rotationSpeed * direction * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Bullet"))
        {
            return;
        }


        if (collision.GetComponent<ShootingAction>() is not null)
        {
            collision.GetComponent<ShootingAction>().Action();
        }

        Destroy(gameObject);
    }
}
