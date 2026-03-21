using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] private Map _mapPrefab;
    [SerializeField] private Survior _surviorPrefab;
    [SerializeField] private Player _playerPrefab;

    public override void InstallBindings()
    {
        BindSurvior(_mapPrefab.SurviorSpawnPoint);
        Container.InstantiatePrefabForComponent<Map>(_mapPrefab);
        Container.InstantiatePrefab(_playerPrefab);
    }

    private void BindSurvior(Vector3 spawnPoint)
    {
        Survior survior = Container.InstantiatePrefabForComponent<Survior>(_surviorPrefab, spawnPoint, Quaternion.identity, null);

        survior.Init(_mapPrefab.WayPoints);
        Container.Bind<Survior>().FromInstance(survior).AsSingle();
    }
}
