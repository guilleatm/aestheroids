using System;
using Godot;

public interface SpawnUseCase
{
	public void Spawn<T>(T node, float radius, Node parent) where T : Node3D;
}
