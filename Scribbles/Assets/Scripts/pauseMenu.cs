using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject pausePanel;
    public Slider sfxSlider;
    public Slider musicSlider;
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
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
