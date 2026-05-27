using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Time.timeScale = 0;
        }    
    }

    public void Continue()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Time.timeScale = 1;
        GameManager.lastSceneEntered = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("menuScene");
        GameManager.completedScene = false;
    }
}
