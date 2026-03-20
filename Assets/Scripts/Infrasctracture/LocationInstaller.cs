using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] private Transform _surviorStartPoint;
    [SerializeField] private Transform _surviorDestanationPoint;
    [SerializeField] private GameObject _surviorPrefab;

    public override void InstallBindings()
    {
        BindSurviorDestinationPoint();
        BindSurvior();
    }

    private void BindSurviorDestinationPoint()
    {
        Container.Bind<Transform>().FromInstance(_surviorDestanationPoint).AsSingle();
    }

    private void BindSurvior()
    {
        Survior survior = Container.InstantiatePrefabForComponent<Survior>(_surviorPrefab, _surviorStartPoint.position, Quaternion.identity, null);

        Container.Bind<Survior>().FromInstance(survior).AsSingle();
    }
}
