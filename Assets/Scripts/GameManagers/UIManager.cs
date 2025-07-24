using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _scoreTextos;

    public static UIManager Instance {  get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    /// <summary>
    /// Update score in UI
    /// </summary>
    /// <param name="score"></param>
    public void UpdateUIScore(int score)
    {
        _scoreTextos.text = score.ToString();
    }
}
