using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _destroyPoint;

    private void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= _destroyPoint)
        {
            Destroy(this.gameObject);
        }
    }
}
