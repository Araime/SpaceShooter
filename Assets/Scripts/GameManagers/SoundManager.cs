using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    /// <summary>
    /// Start playing the music
    /// </summary>
    public void PlayMusic(AudioSource track, bool isScheduled = false, float Schedule = 0f)
    {
        if (isScheduled)
        {
            track.time = Schedule;
            track.Play();
        }
        else
        {
            track.Play();
        }
    }
}
