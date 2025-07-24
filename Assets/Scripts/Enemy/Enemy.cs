using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _firePos;
    [SerializeField] private GameObject _laser;
    [SerializeField] private float _minShootTime;
    [SerializeField] private float _maxShootTime;

    private void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    /// <summary>
    /// Enemy shooting func
    /// </summary>
    private void Shoot()
    {
        Instantiate(_laser, _firePos.transform.position, _firePos.transform.rotation);
    }

    /// <summary>
    /// Regular shooting
    /// </summary>
    /// <returns></returns>
    IEnumerator ShootRoutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(Random.Range(_minShootTime, _maxShootTime));
        }
    }
}
