using UnityEngine;

public class SoundsStorage : MonoBehaviour
{
    [SerializeField] private AudioSource _titleTheme;
    [SerializeField] private AudioSource _creditsTheme;
    [SerializeField] private AudioSource[] _flyThemes;

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
