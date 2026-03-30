using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

public class ZombiePool : MonoBehaviour
{
    [SerializeField] private List<Zombie> _zombiePrefabs;
    [SerializeField] private Transform _zombieContainer;
    [SerializeField] private ZombieType _zombieType;

    private Survior _survior;
    private ObjectPool<Zombie> _pool;

    private int _poolCapacity = 10;
    private int _poolMaxSize = 10;

    public ZombieType ZombieType => _zombieType;

    [Inject]
    private void Construct(Survior survior)
    {
        _survior = survior;
    }

    private void Awake()
    {
        _pool = CreatePool();
    }

    public void SpawnZombieIn(Vector3 point)
    {
        Zombie zombie = _pool.Get();
        zombie.Init(point, _survior);

        zombie.Died += ReleaseZombie;
    }

    private ObjectPool<Zombie> CreatePool()
    {
        return new ObjectPool<Zombie>
            (
                createFunc: () => InstantiateZombie(),
                actionOnRelease: (zombie) => zombie.gameObject.SetActive(false),
                actionOnGet: (zombie) => GetZombie(zombie),
                actionOnDestroy: (zombie) => Destroy(zombie.gameObject),
                collectionCheck: true,
                defaultCapacity: _poolCapacity,
                maxSize: _poolMaxSize
            );
    }

    private void GetZombie(Zombie zombie)
    {
        zombie.gameObject.SetActive(true);
    }

    private Zombie InstantiateZombie()
    {
        Zombie zombie = Instantiate(_zombiePrefabs[Random.Range(0,_zombiePrefabs.Count)]);

        zombie.transform.SetParent(_zombieContainer);

        return zombie;
    }

    private void ReleaseZombie(Zombie zombie)
    {
        zombie.Died -= ReleaseZombie;
        _pool.Release(zombie);
    }
}