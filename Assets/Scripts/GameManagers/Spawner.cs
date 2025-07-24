using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private float _timeBetweenSpawns;
    [SerializeField] private float minX, maxX;
    [SerializeField] private float minY, maxY;
    [SerializeField] private float _spawnTime;

    private void Update()
    {
        if (Time.time > _spawnTime)
        {
            Spawn();
            _spawnTime = Time.time + _timeBetweenSpawns;
        }
    }

    /// <summary>
    /// Spawn some objects in random position
    /// </summary>
    private void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(_prefabs[Random.Range(0, _prefabs.Length)],
            transform.position + new Vector3(randomX, randomY, 0f),
            transform.rotation);
    }
}
