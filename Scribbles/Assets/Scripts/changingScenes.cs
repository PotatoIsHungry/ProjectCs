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
    void Start()
    {
        GameManager.lastSceneEntered = SceneManager.GetActiveScene().name;
        textToEnter.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInZone && Keyboard.current.pKey.isPressed)
        {
            GameManager.lastSceneExited = SceneManager.GetActiveScene().name;
            Console.Write(GameManager.lastSceneExited);
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
