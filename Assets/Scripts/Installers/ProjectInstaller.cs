using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private ProjectManager projectManager;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private Description description;
    public override void InstallBindings()
    {
        Container.Bind<ProjectManager>().FromInstance(projectManager).AsSingle().NonLazy();
        Container.Bind<CameraController>().FromInstance(cameraController).AsSingle().NonLazy();
        Container.Bind<Description>().FromInstance(description).AsSingle().NonLazy();
    }
}