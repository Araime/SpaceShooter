using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private int _currentIndex;
    private int _maxIndex = -1;
    private AudioSource _currentTrack;
    private bool _isNeedChange = false;
    private bool _isBusy = false;

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

    private void Update()
    {
        if (_currentTrack != null && !_currentTrack.loop)
        {
            CheckPlaying();
        }

        if (_isNeedChange && !_isBusy)
        {
            StartChangeMusic();
        }
    }

    /// <summary>
    /// Start playing music
    /// </summary>
    public void PlayMusic(AudioSource track, bool isSkipped = false, float Position = 0f)
    {
        if (track == null) return;

        _currentTrack = track;

        if (isSkipped)
        {
            _currentTrack.time = Position;
            _currentTrack.Play();
        }
        else
        {
            _currentTrack.Play();
        }
    }

    /// <summary>
    /// Start playing flight music
    /// </summary>
    public void PlayFlightMusic()
    {
        UpdateMusicIndex();
        PlayMusic(_currentTrack);
    }

    /// <summary>
    /// Update the current song index
    /// </summary>
    public void UpdateMusicIndex()
    {
        if (_maxIndex < 0)
        {
            _maxIndex = SoundsStorage.Instance._flyThemes.Length - 1;
            _currentIndex = Random.Range(0, _maxIndex + 1);
        }
        else
        {
            _currentIndex++;

            if (_currentIndex > _maxIndex)
            {
                _currentIndex = 0;
            }
        }

        _currentTrack = SoundsStorage.Instance._flyThemes[_currentIndex];
    }

    /// <summary>
    /// Start the music change
    /// </summary>
    public void StartChangeMusic()
    {
        _isBusy = true;
        _isNeedChange = false;
        StartCoroutine(TrackDelay());
    }

    /// <summary>
    /// Change flight track
    /// </summary>
    public void ChangeFlightTrack()
    {
        UpdateMusicIndex();
    }

    /// <summary>
    /// Check if the music is playing
    /// </summary>
    public void CheckPlaying()
    {
        if (_currentTrack.isPlaying) return;

        _isNeedChange = true;
    }

    /// <summary>
    /// Adds a delay before changing tracks
    /// </summary>
    /// <returns></returns>
    private IEnumerator TrackDelay()
    {
        ChangeFlightTrack();
        yield return new WaitForSeconds(2f);
        PlayMusic(_currentTrack);
        _isBusy = false;
    }
}
