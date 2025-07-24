using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidBody;
    private float _destroyTime = 3f;
    private int _enemyHitScore = 2;
    private int _asteroidHitScore = 1;

    private void Awake()
    {
        Destroy(gameObject, _destroyTime);
    }

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.velocity = transform.up * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Instantiate(EffectsStorage.Instance._playerExplosionEffect, collision.transform.position, Quaternion.identity);
            PlayerScores.UpdateScore(_enemyHitScore);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Asteroid"))
        {
            Instantiate(EffectsStorage.Instance._targetExplosionEffect, collision.transform.position, Quaternion.identity);
            PlayerScores.UpdateScore(_asteroidHitScore);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
