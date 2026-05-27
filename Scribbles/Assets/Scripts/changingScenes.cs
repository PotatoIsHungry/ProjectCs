using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class changingScenes : MonoBehaviour
{

    private bool playerInZone = false;
    public string sceneName;
    public TMP_Text textToEnter;
    public string requiredLevel;
    private Transform doorframe;
    void Start()
    {
        doorframe = GetComponent<Transform>();
        textToEnter.enabled = false;
        SaveSystem.SaveGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInZone && Keyboard.current.pKey.isPressed)
        {
            if (SceneManager.GetActiveScene().name.Equals("mainScene"))
            {
                GameManager.position = new Vector3(doorframe.position.x, doorframe.position.y, 0);
            }
            GameManager.completedScene = true;
            GameManager.lastSceneExited = SceneManager.GetActiveScene().name;

            GameManager.lastSceneEntered = sceneName;
            SceneManager.LoadScene(sceneName);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            if (requiredLevel.Equals("") || requiredLevel.Equals(GameManager.lastSceneExited) || sceneName.Equals(GameManager.lastSceneEntered))
            {
                playerInZone = true;
                textToEnter.text = "PRESS P TO ENTER";
            }
            else
            {
                textToEnter.text = "LO CKED";
            }

            textToEnter.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            textToEnter.enabled = false;
        }
    }
}
