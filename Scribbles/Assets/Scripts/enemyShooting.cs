using UnityEngine;

public class enemyShooting : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPosition;
    private GameObject player;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 8.5)
        {
            timer += Time.deltaTime;

            if (timer > 1.5)
            {
                timer = 0;
                shoot();
            }
        }



    }

    void shoot()
    {
        Instantiate(bullet, bulletPosition.position, bulletPosition.rotation);
    }
}
