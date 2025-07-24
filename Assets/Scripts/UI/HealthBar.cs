using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    /// <summary>
    /// Update UI health to max health
    /// </summary>
    /// <param name="health"></param>
    public void SetMaxHealth(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;
    }

    /// <summary>
    /// Update UI health
    /// </summary>
    /// <param name="health"></param>
    public void SetHealth(int health)
    {
        _slider.value = health;
    }
}
