using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : ObjectPool
{
    //[SerializeField] private List<Wave> _waves;

    [SerializeField] private GameObject[] _enemyTemplates;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Player _player;
    [SerializeField] private int _nextEnemyCount = 5;
    [SerializeField] private float _secondsBetweeneSpawn = 2;

    //private Wave _currentWave;
    private int _currentNumberEnemies;
    private int _currentWaveNumber = 1;
    private float _timeAfterLastSpawn;
    private int _spawned;
    
    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {        
        Initialize(_enemyTemplates);
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentNumberEnemies == 0)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _secondsBetweeneSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _timeAfterLastSpawn = 0;
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
                _spawned++;
                EnemyCountChanged?.Invoke(_spawned, _currentNumberEnemies);
            }
        }

            if (_currentNumberEnemies <= _spawned)
            {
                if (_currentNumberEnemies == _spawned)
                    AllEnemySpawned?.Invoke();

                _currentNumberEnemies = 0;
            }
    }
        
    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
        enemy.GetComponent<Enemy>().Init(_player);
        enemy.GetComponent<Enemy>().Dying += OnEnemyDying;
    }

    private void SetWave(int index)
    {
        _currentNumberEnemies = index * _nextEnemyCount;
    }

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        _player.AddMoney(enemy.Reward);
    }
}