using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _leftBorder;
    [SerializeField] private float _rightBorder;
    private Rigidbody2D _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0 && transform.position.x >= _rightBorder)
        {
            _rigidBody.velocity = Vector2.zero;
        }
        else if (horizontalInput < 0 && transform.position.x <= _leftBorder)
        {
            _rigidBody.velocity = Vector2.zero;
        }
        else
        {
            _rigidBody.velocity = new Vector2(horizontalInput * _moveSpeed, _rigidBody.velocity.y);
        }
    }
}
