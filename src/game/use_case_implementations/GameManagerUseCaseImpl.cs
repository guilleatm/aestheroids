using Godot;
using Chickensoft.AutoInject;
using Chickensoft.Introspection;

namespace Aestheroids;

public partial class GameManagerUseCaseImpl : Node, GameManagerUseCase
{
    public override void _Notification(int what) => this.Notify(what);

    public Observable<int> Score { get; set; } = new Observable<int>(0);


    public GameManagerUseCaseImpl Create(AsteroidManagerUseCase<Asteroid> asteroidManagerUseCase)
    {
        asteroidManagerUseCase.OnAsteroidAvoided += OnAsteroidAvoided;
        return this;
    }

    void OnAsteroidAvoided()
    {
        Score.Value += 1;
    }

}