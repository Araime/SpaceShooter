using UnityEngine;

public class SoundsStorage : MonoBehaviour
{
    public AudioSource _titleTheme;
    public AudioSource _creditsTheme;
    public AudioSource[] _flyThemes;

    public static SoundsStorage Instance { get; private set; }

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
}
