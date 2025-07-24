using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _currentHealth, _maxHealth;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private int _shipCollisionDamage;
    [SerializeField] private float _immortalityTime;
    private bool _isImmortal = false;

    private void Start()
    {
        EffectsStorage.Instance._immortalEffect.SetActive(false);
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_currentHealth);
    }

    /// <summary>
    /// Take tamage to the ship
    /// </summary>
    /// <param name="damage"></param>
    public void DealDamage(int damage)
    {
        if (_isImmortal)
        {
            Instantiate(EffectsStorage.Instance._damageEffect, transform.position, Quaternion.identity);
        }
        else
        {
            _currentHealth -= damage;
            _healthBar.SetHealth(_currentHealth);

            if (_currentHealth <= 0f)
            {
                Instantiate(EffectsStorage.Instance._playerExplosionEffect, transform.position, Quaternion.identity);
                GameManager.Instance.GameOver();
                gameObject.SetActive(false);
            }
            else
            {
                Instantiate(EffectsStorage.Instance._damageEffect, transform.position, Quaternion.identity);
            }
        }
    }

    /// <summary>
    /// Restore the ship health
    /// </summary>
    /// <param name="power"></param>
    public void RepairShip(int power)
    {
        _currentHealth += power;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        _healthBar.SetHealth(_currentHealth);
    }

    /// <summary>
    /// Switch on immortality
    /// </summary>
    public void StartImmortality()
    {
        StartCoroutine(ImmortalityDelay());
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (_isImmortal)
            {
                Instantiate(EffectsStorage.Instance._playerExplosionEffect, collision.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                return;
            }

            DealDamage(_shipCollisionDamage);
        }
    }

    /// <summary>
    /// Countdown immortality delay
    /// </summary>
    /// <returns></returns>
    private IEnumerator ImmortalityDelay()
    {
        _isImmortal = true;
        EffectsStorage.Instance._immortalEffect.SetActive(true);

        yield return new WaitForSeconds(_immortalityTime);

        _isImmortal = false;
        EffectsStorage.Instance._immortalEffect.SetActive(false);
    }
}
