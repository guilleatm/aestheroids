using Godot;
using Chickensoft.AutoInject;
using Chickensoft.Introspection;

namespace Aestheroids;

[Meta(typeof(IDependent), typeof(IProvider))]
public partial class Game : Node, IProvide<ScreenDragToRotationUseCase>
{
    public override void _Notification(int what) => this.Notify(what);

    [Export] GameManager m_GameManagerUseCase;
    [Export] AsteroidManager m_AsteroidManagerUseCase;
    [Export] UIManager m_UIManagerUseCase;


    // PROVIDED DEPENDENCIES
    ScreenDragToRotationUseCase m_ScreenDragToRotationUseCase;
    ScreenDragToRotationUseCase IProvide<ScreenDragToRotationUseCase>.Value() => m_ScreenDragToRotationUseCase;


    // DEPENDENCIES

    [Dependency]
    public RandomNumberGenerator m_RandomNumberGenerator => this.DependOn<RandomNumberGenerator>();

    public void OnResolved()
    {
        const float SPAWN_RADIUS = 10f;
        SpawnUseCase spawnUseCase = new SpawnUseCaseImpl(m_RandomNumberGenerator, SPAWN_RADIUS);

        m_AsteroidManagerUseCase.Create(spawnUseCase);
        m_GameManagerUseCase.Create(m_AsteroidManagerUseCase);
        m_UIManagerUseCase.Create(m_GameManagerUseCase);




        // PROVIDE DEPENDENCIES

        m_ScreenDragToRotationUseCase = new ScreenDragToRotationUseCaseImpl();
        this.Provide();
    }
}