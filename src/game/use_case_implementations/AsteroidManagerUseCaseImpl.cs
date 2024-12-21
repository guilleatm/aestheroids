using Godot;
using System;

namespace Aestheroids;
public partial class AsteroidManagerUseCaseImpl : Node, AsteroidManagerUseCase<Asteroid>
{
	[Export] PackedScene m_AsteroidPackedScene;
	[Export] Node3D m_AsteroidsContainer;
	[Export] Timer m_Timer;

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
		GD.Print("Spaewn asteroid");
		Asteroid asteroid = m_AsteroidPackedScene.Instantiate<Asteroid>();
		m_SpawnUseCase.Spawn<Asteroid>(asteroid, m_AsteroidsContainer);
	}

}
