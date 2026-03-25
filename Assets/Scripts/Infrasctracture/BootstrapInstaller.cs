using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private EventSystem _eventSystem;

    public override void InstallBindings()
    {
        BindInputReader();
        Container.InstantiatePrefabForComponent<EventSystem>(_eventSystem);
    }

    private void BindInputReader() 
    {
        InputReader inputReader = Container.InstantiatePrefabForComponent<InputReader>(_inputReader,Vector3.zero,Quaternion.identity,null);

        Container.Bind<InputReader>().FromInstance(inputReader).AsSingle();
    }
}
