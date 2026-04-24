using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public void SetUp()
    {
        gameObject.SetActive(true);
    }

    public void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void goToMainMenu()
    {
        GameManager.lastSceneEntered = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("menuScene");
    }
}
