using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceController : MonoBehaviour
{
    private static AudioSourceController instance = null;

    public static AudioSourceController Instance
    {
        get { return instance; }
    }

    public AudioSource audioSource;
    public AudioClip puzzleSuccess;
    public AudioClip puzzleFailure;

    public AudioClip mainTheme;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if(!audioSource.isPlaying)
        {
            PlayMainTheme();
        }
    }

    public void PlaySuccess()
    {
        audioSource.clip = puzzleSuccess;
        audioSource.Play();
    }

    public void PlayFailure()
    {
        audioSource.clip = puzzleFailure;
        audioSource.Play();
    }

    public void PlayMainTheme()
    {
        audioSource.clip = mainTheme;
        audioSource.Play();
    }
}
