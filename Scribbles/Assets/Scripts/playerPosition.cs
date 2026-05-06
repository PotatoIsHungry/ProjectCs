using Unity.VisualScripting;
using UnityEngine;

public class playerPosition : MonoBehaviour
{
    Transform playerPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            playerPos = GetComponent<Transform>();
            playerPos.position = new Vector3(GameManager.position.x, GameManager.position.y, 0);
    }

}
