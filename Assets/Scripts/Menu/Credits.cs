using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] private GameObject _creditsScreen;
    [SerializeField] private AudioSource _creditsTheme;
    private float _startTime = 0.5f;
    private float _endTime = 37f;

    private void Start()
    {
        StartCoroutine(CreditsRun());
        SoundManager.Instance.PlayMusic(_creditsTheme, true, 112.5f);
    }

    private IEnumerator CreditsRun()
    {
        yield return new WaitForSeconds(_startTime);
        
        _creditsScreen.SetActive(true);

        yield return new WaitForSeconds(_endTime);

        SceneManager.LoadScene(0);
    }
}
