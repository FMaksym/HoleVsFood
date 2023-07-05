using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private LevelManager level;
    [SerializeField] private GameUiManager uiManager;
    [SerializeField] private Magnet magnet;

    public override void InstallBindings()
    {
        Container.Bind<LevelManager>().FromInstance(level).AsSingle();
        Container.Bind<GameUiManager>().FromInstance(uiManager).AsSingle();
        Container.Bind<Magnet>().FromInstance(magnet).AsSingle();
    }
}