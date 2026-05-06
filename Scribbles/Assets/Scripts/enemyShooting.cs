using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyShooting : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPosition;
    private GameObject player;
    private float timer;
    private float playerDistance = 35f;
    public float shootingTime;

    Scene scene;
    string sceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneName.Equals("tutorialScene") || sceneName.Equals("Test Scene") || sceneName.Equals("curiositiesScene"))
            return;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < playerDistance)
        {
            timer += Time.deltaTime;

            if (timer > shootingTime)
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
