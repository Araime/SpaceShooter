using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _downSpeed;
    [SerializeField] private float _destroyPoint;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _minFlightTime;
    [SerializeField] private float _maxFlightTime;
    private float _leftBorder = -8;
    private float _rightBorder = 8;
    private float _minDistance = 0.3f;
    private Vector3 _newPos;
    private bool _isMoving = false;

    private float _distanceToTarget
    {
        get => Vector3.Distance(transform.position, _newPos);
    }

    private void Start()
    {
        StartCoroutine(FlightRoutine());
    }

    private void Update()
    {
        if (_distanceToTarget > _minDistance && _isMoving)
        {
            transform.Translate(Vector3.down * _downSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(_newPos.x, transform.position.y, 0f),
                _moveSpeed);
        }
        else
        {
            _isMoving = false;
        }

        if (!_isMoving)
        {
            transform.Translate(Vector3.down * _downSpeed * Time.deltaTime);
        }

        if (transform.position.y <= _destroyPoint)
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Set new destination
    /// </summary>
    private void SetDestination()
    {
        _newPos = new Vector3(Random.Range(_leftBorder, _rightBorder), transform.position.y, 0f);
        _isMoving = true;
    }

    IEnumerator FlightRoutine()
    {
        while (true)
        {
            SetDestination();
            yield return new WaitForSeconds(Random.Range(_minFlightTime, _maxFlightTime));
        }
    }
}
