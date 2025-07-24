using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseScreen;
    private static bool _isPaused;

    private void Start()
    {
        _pauseScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    /// <summary>
    /// Pause or unpause game and show/hide pause menu
    /// </summary>
    public void PauseUnpause()
    {
        if (_isPaused)
        {
            _isPaused = false;
            _pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            _isPaused = true;
            _pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    /// <summary>
    /// Return to main menu
    /// </summary>
    public void MenuButtonClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Get isPaused status
    /// </summary>
    /// <returns></returns>
    public static bool GetPauseStatus()
    {
        return _isPaused;
    }
}
