using Godot;
using Chickensoft.AutoInject;
using Chickensoft.Introspection;

namespace Aestheroids;

[Meta(typeof(IDependent))]
public partial class Game : Node
{
    public override void _Notification(int what) => this.Notify(what);

    [Export] GameManagerUseCaseImpl m_GameManagerUseCase;
    [Export] AsteroidManagerUseCaseImpl m_AsteroidManagerUseCase;
    [Export] UIManagerUseCaseImpl m_UIManagerUseCase;

    [Dependency]
    public RandomNumberGenerator m_RandomNumberGenerator => this.DependOn<RandomNumberGenerator>();

    public void OnResolved()
    {
        const float SPAWN_RADIUS = 5f;
        SpawnUseCase spawnUseCase = new SpawnUseCaseImpl(m_RandomNumberGenerator, SPAWN_RADIUS);

        m_AsteroidManagerUseCase.Create(spawnUseCase);
        m_GameManagerUseCase.Create(m_AsteroidManagerUseCase);
        m_UIManagerUseCase.Create(m_GameManagerUseCase);



        GD.Print($"{nameof(Game)} dependencies resolved.");
    }
}