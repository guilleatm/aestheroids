using Godot;
using System;

namespace Aestheroids;
public partial class AsteroidManager : Node, IAsteroidManager<Asteroid>
{
	public event Action OnAsteroidAvoided;

	[Export] PackedScene m_AsteroidPackedScene;
	[Export] Node3D m_AsteroidsContainer;
	[Export] Area3D m_AvoidArea;
	[Export] Timer m_Timer;
	[Export] float m_ImpulseMagnitude;

	SpawnUseCase m_SpawnUseCase;
	public AsteroidManager Create(SpawnUseCase spawnUseCase)
	{
		m_SpawnUseCase = spawnUseCase;

		m_AvoidArea.BodyExited += OnAsteroidExitedAvoidArea;

		m_Timer.Timeout += SpawnAsteroid;
		m_Timer.Start();

		return this;
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

		body.GetParent().RemoveChild(body);
		body.QueueFree();


		// SceneTreeTimer timer = GetTree().CreateTimer(FREE_ASTEROID_DELAY);
		// timer.Timeout += FreeAsteroid;

		// void FreeAsteroid()
		// {
		// 	// GD.Print(body.Name);
		// 	timer.Timeout -= FreeAsteroid;

		// }

	}
}
