using Chickensoft.AutoInject;
using Chickensoft.Introspection;
using Godot;
using System;

namespace Aestheroids;

[Meta(typeof(IDependent))]
public partial class AsteroidManager : Node, IAsteroidManager<Asteroid>
{
	public event Action OnAsteroidAvoided;
	public event Action<Asteroid> OnAsteroidCollided;

	public override void _Notification(int what) => this.Notify(what);

	[Export] PackedScene m_AsteroidPackedScene;
	[Export] Node3D m_AsteroidsContainer;
	[Export] Area3D m_AvoidArea;
	[Export] Timer m_Timer;
	[Export] float m_ImpulseMagnitude;

	[Dependency]
	public IGameManager m_GameManager => this.DependOn<IGameManager>();

	SpawnUseCase m_SpawnUseCase;
	DestroyAsteroidUseCase<Asteroid> m_DestroyAsteroidUseCase;
	public AsteroidManager Create(Planet planet, SpawnUseCase spawnUseCase, DestroyAsteroidUseCase<Asteroid> destroyAsteroidUseCase)
	{
		m_SpawnUseCase = spawnUseCase;
		m_DestroyAsteroidUseCase = destroyAsteroidUseCase;

		m_AvoidArea.BodyExited += OnAsteroidExitedAvoidArea;
		planet.OnAsteroidCollided += OnAsteroidCollidedInternal;

		OnAsteroidCollided += OnAsteroidCollidedCallback;

		m_Timer.Timeout += SpawnAsteroid;

		return this;
	}

	public void OnResolved()
	{
		m_GameManager.OnGameOver += OnGameOver;
		m_GameManager.OnGameStarted += OnGameStarted;
	}

	void OnGameStarted()
	{
		m_Timer.Start();
	}

	void OnGameOver()
	{
		m_Timer.Stop();

		foreach (Node3D node in m_AsteroidsContainer.GetChildren())
		{
			CallDeferred(nameof(FreeAsteroid), node);
		}
	}

	void OnAsteroidCollidedInternal(Node3D body)
	{
		if (body is Asteroid asteroid)
		{
			OnAsteroidCollided.Invoke(asteroid);
		}
	}

	void OnAsteroidCollidedCallback(Asteroid asteroid)
	{
		m_DestroyAsteroidUseCase.DestroyAsteroid(asteroid);
		CallDeferred(nameof(FreeAsteroid), asteroid);
	}



	public void SpawnAsteroid()
	{
		Asteroid asteroid = m_AsteroidPackedScene.Instantiate<Asteroid>();
		m_SpawnUseCase.Spawn<Asteroid>(asteroid, m_AsteroidsContainer);

		Vector3 impulseDirection = -asteroid.GlobalPosition.Normalized();
		asteroid.RigidBody3D.ApplyCentralImpulse(impulseDirection * m_ImpulseMagnitude);
	}

	void OnAsteroidExitedAvoidArea(Node3D body)
	{
		const int FREE_ASTEROID_DELAY = 5;
		OnAsteroidAvoided?.Invoke();

		CallDeferred(nameof(FreeAsteroid), body);
	}

	public void FreeAsteroid(Node3D node3D)
	{
		if (node3D.IsQueuedForDeletion()) return;

		node3D.GetParent().RemoveChild(node3D);
		node3D.QueueFree();
	}
}
