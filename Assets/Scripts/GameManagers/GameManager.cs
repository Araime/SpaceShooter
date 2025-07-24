using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;

    public static GameManager Instance { get; private set; }

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

    private void Start()
    {
        _gameOverScreen.SetActive(false);
    }

    /// <summary>
    /// Stop the game when ship is destroyed
    /// </summary>
    public void GameOver()
    {
        StartCoroutine(GameOverDelay());
    }

    /// <summary>
    /// Delay before game over screen
    /// </summary>
    /// <returns></returns>
    private IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(1f);
        _gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Restart current level
    /// </summary>
    public void RestartButtonClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
