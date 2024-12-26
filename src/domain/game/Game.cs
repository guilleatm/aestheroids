using Godot;
using Chickensoft.AutoInject;
using Chickensoft.Introspection;

namespace Aestheroids;

[Meta(typeof(IDependent), typeof(IProvider))]
public partial class Game : Node, IProvide<ScreenDragToRotationUseCase>, IProvide<IGameManager>
{
    public override void _Notification(int what) => this.Notify(what);

    [Export] GameManager m_GameManager;
    [Export] AsteroidManager m_AsteroidManager;
    [Export] UIManager m_UIManager;
    [Export] Planet m_Planet;


    // PROVIDED DEPENDENCIES
    ScreenDragToRotationUseCase m_ScreenDragToRotationUseCase;
    ScreenDragToRotationUseCase IProvide<ScreenDragToRotationUseCase>.Value() => m_ScreenDragToRotationUseCase;

    IGameManager IProvide<IGameManager>.Value() => m_GameManager;


    // DEPENDENCIES

    [Dependency]
    public RandomNumberGenerator m_RandomNumberGenerator => this.DependOn<RandomNumberGenerator>();

    public void OnResolved()
    {
        // INSTALL

        const float SPAWN_RADIUS = 15f;
        SpawnUseCase spawnUseCase = new SpawnUseCaseImpl(m_RandomNumberGenerator, SPAWN_RADIUS);

        IParticlesRepository particlesRepository = new ParticlesRepository();

        DestroyAsteroidUseCase<Asteroid> destroyAsteroidUseCase = new DestroyAsteroidUseCaseImpl(particlesRepository);

        m_AsteroidManager.Create(m_Planet, spawnUseCase, destroyAsteroidUseCase);
        m_UIManager.Create();
        m_GameManager.Create(m_UIManager, m_AsteroidManager);




        // PROVIDE DEPENDENCIES

        m_ScreenDragToRotationUseCase = new ScreenDragToRotationUseCaseImpl();
        this.Provide();
    }
}