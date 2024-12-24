using Godot;
using Chickensoft.AutoInject;
using Chickensoft.Introspection;

namespace Aestheroids;

public partial class GameManager : Node, IGameManager
{
    public override void _Notification(int what) => this.Notify(what);

    public Observable<int> Score { get; set; } = new Observable<int>(0);

    public GameManager Create(IAsteroidManager<Asteroid> asteroidManagerUseCase)
    {
        asteroidManagerUseCase.OnAsteroidAvoided += OnAsteroidAvoided;
        return this;
    }

    void OnAsteroidAvoided()
    {
        Score.Value += 1;
    }

}