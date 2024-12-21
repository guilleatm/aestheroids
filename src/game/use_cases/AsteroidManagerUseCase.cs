using Godot;
using System;

namespace Aestheroids;

public interface AsteroidManagerUseCase<T> where T : Node3D
{
	public event Action OnAsteroidAvoided;
	public void SpawnAsteroid();
}
