using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class menuManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject pausePanel;
    public Slider sfxSlider;
    public Slider musicSlider;
    public void Start()
    {
        MusicManager.instance.setMusicVolume(GameManager.musicVolume);

    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void setSettings()
    {
        sfxSlider.value = GameManager.SFXVolume;
        musicSlider.value = GameManager.musicVolume;
        settingsPanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void setPause()
    {
        settingsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void soundChangeSFX()
    {
        GameManager.SFXVolume = sfxSlider.value;
        Debug.Log(sfxSlider.value);
    }

    public void soundChangeMusic()
    {
        GameManager.musicVolume = musicSlider.value;
        MusicManager.instance.setMusicVolume(GameManager.musicVolume);
    }
}
