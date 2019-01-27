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
    public AudioClip puzzle1Playing;
    public AudioClip puzzle2Playing;

    public AudioClip mainTheme;

    public AudioClip dialog1;
    public AudioClip dialog2;

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

    public void PlayPuzzle1Audio()
    {
        audioSource.clip = puzzle1Playing;
        audioSource.Play();
    }

    public void PlayPuzzle2Audio()
    {
        audioSource.clip = puzzle2Playing;
        audioSource.Play();
    }

    public void PlayMainTheme()
    {
        audioSource.clip = mainTheme;
        audioSource.Play();
    }

    public void PlayDialog1Audio()
    {
        audioSource.clip = dialog1;
        audioSource.Play();
    }

    public void PlayDialog2Audio()
    {
        audioSource.clip = dialog2;
        audioSource.Play();
    }
}
