using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyShooting : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPosition;
    private GameObject player;
    private float timer;

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

        if(sceneName.Equals("Tutorial Scene") || sceneName.Equals("Test Scene") || sceneName.Equals("Curiosities Scene"))
        return;

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
