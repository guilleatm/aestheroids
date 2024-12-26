using Godot;
using System;

public interface IPlanet
{
	public event Action<Node3D> OnAsteroidCollided;
}
