using Godot;
using Chickensoft.AutoInject;
using Chickensoft.Introspection;
using System;

namespace Aestheroids;

public partial class GameManager : Node, IGameManager
{
    public event Action OnGameStarted;
    public event Action OnGameOver;

    public override void _Notification(int what) => this.Notify(what);

    public Observable<int> Score { get; set; } = new Observable<int>(0);

    IAsteroidManager<Asteroid> m_AsteroidManager;

    public GameManager Create(UIManager uiManager, IAsteroidManager<Asteroid> asteroidManager)
    {
        m_AsteroidManager = asteroidManager;

        uiManager.OnPlayPressed += () => OnGameStarted.Invoke();
        asteroidManager.OnAsteroidCollided += (Asteroid _) => OnGameOver.Invoke();

        OnGameStarted += OnGameStartedCallback;
        OnGameOver += OnGameOverCallback;

        return this;
    }

    private void OnGameStartedCallback()
    {
        Score.Value = 0;

        m_AsteroidManager.OnAsteroidAvoided += OnAsteroidAvoided;
    }

    private void OnGameOverCallback()
    {
        m_AsteroidManager.OnAsteroidAvoided -= OnAsteroidAvoided;
    }

    void OnAsteroidAvoided()
    {
        Score.Value += 1;
    }
}