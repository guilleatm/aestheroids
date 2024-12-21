using Godot;
using System;

namespace Aestheroids;
public partial class AsteroidManagerUseCaseImpl : Node, AsteroidManagerUseCase<Asteroid>
{
	[Export] PackedScene m_AsteroidPackedScene;
	[Export] Node3D m_AsteroidsContainer;
	[Export] Timer m_Timer;
	[Export]
	float m_ImpulseMagnitude;

	SpawnUseCase m_SpawnUseCase;
	public AsteroidManagerUseCaseImpl Create(SpawnUseCase spawnUseCase)
	{
		m_SpawnUseCase = spawnUseCase;

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

}
