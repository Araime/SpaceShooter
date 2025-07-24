using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _destroyTime = 3f;

    private void Awake()
    {
        Destroy(gameObject, _destroyTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }
}
