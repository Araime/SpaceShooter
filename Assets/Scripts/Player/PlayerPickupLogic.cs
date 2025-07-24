using UnityEngine;

public class PlayerPickupLogic : MonoBehaviour
{
    [SerializeField] private int _pickupScoreAmount = 10;
    [SerializeField] private int _healthPickupAmount;
    private PlayerHealth _playerHealth;
    private PlayerShooting _playerShooting;

    private void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _playerShooting = GetComponent<PlayerShooting>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Health"))
        {
            _playerHealth.RepairShip(_healthPickupAmount);

            Instantiate(EffectsStorage.Instance._pickupEffect, collision.transform.position, Quaternion.identity);
            Instantiate(EffectsStorage.Instance._healEffectText, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Score"))
        {
            PlayerScores.UpdateScore(_pickupScoreAmount);
            Instantiate(EffectsStorage.Instance._pickupEffect, collision.transform.position, Quaternion.identity);
            Instantiate(EffectsStorage.Instance._scoreEffectText, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Bonus"))
        {
            _playerHealth.StartImmortality();

            Instantiate(EffectsStorage.Instance._pickupEffect, collision.transform.position, Quaternion.identity);
            Instantiate(EffectsStorage.Instance._immortalEffectText, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Power"))
        {
            _playerShooting.ActivatePower();
            Instantiate(EffectsStorage.Instance._pickupEffect, collision.transform.position, Quaternion.identity);
            Instantiate(EffectsStorage.Instance._powerEffectText, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
