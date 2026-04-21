using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class changingScenes : MonoBehaviour
{

    private bool playerInZone = false;
    public string sceneName;
    public TMP_Text textToEnter;

    void Start()
    {
        textToEnter.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInZone && Keyboard.current.pKey.isPressed)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
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
