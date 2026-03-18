using UnityEngine;

public class ZombieSpawnPoint : MonoBehaviour
{
    [SerializeField] private int _maxSpawnZombie = 2;

    private int _spawnedZombieCounter;

    public bool IsCanSpawnZombie => _spawnedZombieCounter < _maxSpawnZombie;
    public Vector3 Position { get; private set; }
    public bool IsActive { get; private set; }

    private void Awake()
    {
        Position = transform.position;
        IsActive = false;
        _spawnedZombieCounter = 0;
    }

    public void IncreseSpawnCounter() 
    {
        _spawnedZombieCounter++;
    }

    public void Activate()
    {
        IsActive = true;
    }
}
