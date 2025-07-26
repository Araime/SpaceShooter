using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private int _currentIndex;
    private int _maxIndex;

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
    /// Start playing music
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

    /// <summary>
    /// Start playing flight music
    /// </summary>
    public void PlayFlightMusic()
    {
        _maxIndex = SoundsStorage.Instance._flyThemes.Length - 1;
        _currentIndex = Random.Range(0, _maxIndex + 1);
        SoundsStorage.Instance._flyThemes[_currentIndex].Play();
    }
}
