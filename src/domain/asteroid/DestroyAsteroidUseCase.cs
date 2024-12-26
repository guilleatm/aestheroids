using Godot;
using System;

namespace Aestheroids;
public interface DestroyAsteroidUseCase<T> where T : Node
{
	public void DestroyAsteroid(T asteroid);
}
