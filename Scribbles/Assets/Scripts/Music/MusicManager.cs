using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    private AudioSource audioSource;

    public AudioClip soundtrack;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundtrack;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void setMusicVolume(float volume)
    {
        audioSource.volume = volume;
    }
}