using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform _firePos1;
    [SerializeField] private Transform _firePos2;
    [SerializeField] private Transform _firePos3;
    [SerializeField] private GameObject _laser;
    [SerializeField] private float _timeBetweenShots;
    [SerializeField] private float _empowerDuration;
    [SerializeField] private bool _canShoot;
    private bool _isEmpowered = false;

    private void Start()
    {
        _canShoot = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && _canShoot)
        {
            Shoot();
        }
    }

    /// <summary>
    /// Shooting with laser
    /// </summary>
    public void Shoot()
    {
        Instantiate(_laser, _firePos1.position, _firePos1.rotation);

        if (_isEmpowered)
        {
            Instantiate(_laser, _firePos2.position, _firePos2.rotation);
            Instantiate(_laser, _firePos3.position, _firePos3.rotation);
        }

        StartCoroutine(ShootDelay());
    }

    /// <summary>
    /// Delay before next shoot
    /// </summary>
    /// <returns></returns>
    private IEnumerator ShootDelay()
    {
        _canShoot = false;
        yield return new WaitForSeconds(_timeBetweenShots);
        _canShoot = true;
    }

    /// <summary>
    /// Deactivate additional lasers
    /// </summary>
    /// <returns></returns>
    private IEnumerator DeactivateEmpower()
    {
        yield return new WaitForSeconds(_empowerDuration);
        _isEmpowered = false;
    }

    /// <summary>
    /// Activate additional lasers
    /// </summary>
    public void ActivatePower()
    {
        if (!_isEmpowered)
        {
            _isEmpowered = true;
            StartCoroutine(DeactivateEmpower());
        }
        else
        {
            StopCoroutine(DeactivateEmpower());
            StartCoroutine(DeactivateEmpower());
        }
    }
}
