using UnityEngine;

public class playerShooting : MonoBehaviour
{
    private float speed = 3;

    private float direction = 1;

    public void SetDirection(float dir)
    {
        direction = dir;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Bullet"))
        {
            return;
        }


        if (collision.GetComponent<ShootingAction>())
        {
            collision.GetComponent<ShootingAction>().Action();
        }

        Destroy(gameObject);
    }
}
