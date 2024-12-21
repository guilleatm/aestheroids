using Godot;
using Chickensoft.AutoInject;
using Chickensoft.Introspection;

namespace Aestheroids;

[Meta(typeof(IDependent))]
public partial class Game : Node
{
    public override void _Notification(int what) => this.Notify(what);

    [Export] AsteroidManagerUseCaseImpl m_AsteroidManagerUseCase;

    [Dependency]
    public RandomNumberGenerator m_RandomNumberGenerator => this.DependOn<RandomNumberGenerator>();

    public void OnResolved()
    {
        const float SPAWN_RADIUS = 5f;
        SpawnUseCase spawnUseCase = new SpawnUseCaseImpl(m_RandomNumberGenerator, SPAWN_RADIUS);

        m_AsteroidManagerUseCase.Create(spawnUseCase);


        GD.Print($"{nameof(Game)} dependencies resolved.");
    }
}