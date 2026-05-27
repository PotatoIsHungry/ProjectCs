using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public AudioSource audioDeathScrene;
    public void SetUp()
    {
        audioDeathScrene.PlayOneShot(audioDeathScrene.clip);
        gameObject.SetActive(true);
    }

    public void resetScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void goToMainMenu()
    {
        Time.timeScale = 1;
        GameManager.lastSceneEntered = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("menuScene");
        GameManager.completedScene = false;
    }
}
