using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private ZombiePool _zombiePool;
    [SerializeField] private List<ZombieSpawnPoint> _zombieSpawnPoints;
    [SerializeField] private float DelayBeetweenSpawn = 5f;

    private int _maxSpawnCount = 1000;
    private WaitForSeconds _waitForSeconds;

    private Coroutine _coroutine;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(DelayBeetweenSpawn);
        StartSpawning();
    }

    public void StartSpawning()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(DelayedSpawner()); ;
    }

    public void StopSpawning()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = null;
    }

    private void SpawnZombie()
    {
        foreach (ZombieSpawnPoint zombieSpawnPoint in _zombieSpawnPoints)
        {
            if (zombieSpawnPoint.IsActive == true && zombieSpawnPoint.IsCanSpawnZombie)
            {
                Debug.Log("Spawn");
                _zombiePool.SpawnZombieIn(zombieSpawnPoint.Position);
                zombieSpawnPoint.IncreseSpawnCounter();
            }
        }
    }

    private IEnumerator DelayedSpawner()
    {
        for (int i = 0; i < _maxSpawnCount; i++)
        {
            yield return _waitForSeconds;

            SpawnZombie();
        }
    }
}
