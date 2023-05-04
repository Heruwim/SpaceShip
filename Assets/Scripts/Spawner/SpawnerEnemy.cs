using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : ObjectPool
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweeneSpawn;

    private float _elepsedTime = 0;

    private void Start()
    {
        Initialize(_enemyPrefab);
    }

    private void Update()
    {
        _elepsedTime += Time.deltaTime;
        
        if (_elepsedTime >= _secondsBetweeneSpawn)
        {
            if (TryGetObject(out GameObject enemy)
            {
                _elepsedTime = 0;
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
