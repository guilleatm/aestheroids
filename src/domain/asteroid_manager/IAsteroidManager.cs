using Godot;
using System;

namespace Aestheroids;

public interface IAsteroidManager<T> where T : Node3D
{
	public event Action OnAsteroidAvoided;
	public event Action<Asteroid> OnAsteroidCollided;
	public void SpawnAsteroid();
}
