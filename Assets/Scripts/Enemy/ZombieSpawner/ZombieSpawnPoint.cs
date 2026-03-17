using System.Collections;
using UnityEngine;

public class ZombieSpawnPoint : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private int _maxSpawnZombie = 2;

    private int _spawnedZombieCounter;

    private WaitForSeconds _waitForSeconds;

    public bool IsCanSpawnZombie => _spawnedZombieCounter < _maxSpawnZombie;
    public Vector3 Position { get; private set; }
    public bool IsActive { get; private set; }

    private Coroutine _coroutine;

    private void Awake()
    {
        Position = transform.position;
        _waitForSeconds = new WaitForSeconds(_lifeTime);
        IsActive = false;
    }

    public void IncreseSpawnCounter() 
    {
        _spawnedZombieCounter++;
    }

    public void Activate()
    {
        _spawnedZombieCounter = 0;
        IsActive = true;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
        
        _coroutine = StartCoroutine(Deactivate());
    }

    private IEnumerator Deactivate()
    {
        yield return _waitForSeconds;

        IsActive = false;
        _coroutine = null;
    }
}
