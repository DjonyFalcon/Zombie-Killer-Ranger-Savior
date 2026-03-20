using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private InputReader _inputReader;

    public override void InstallBindings()
    {
        BindInputReader();
    }

    private void BindInputReader() 
    {
        InputReader inputReader = Container.InstantiatePrefabForComponent<InputReader>(_inputReader,Vector3.zero,Quaternion.identity,null);

        Container.Bind<InputReader>().FromInstance(inputReader).AsSingle();
    }
}
