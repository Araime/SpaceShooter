using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string _levelName, _creditsName;
    [SerializeField] private AudioSource _titleTheme;

    private void Start()
    {
        SoundManager.Instance.PlayMusic(_titleTheme);
    }

    /// <summary>
    /// Starting a new game
    /// </summary>
    public void StartButtonClick()
    {
        SceneManager.LoadScene(_levelName);
    }

    /// <summary>
    /// Show developer credits
    /// </summary>
    public void CreditsButtonClick()
    {
        SceneManager.LoadScene(_creditsName);
    }

    /// <summary>
    /// Exit from the game
    /// </summary>
    public void QuitButtonClick()
    {
        Application.Quit();
    }
}
