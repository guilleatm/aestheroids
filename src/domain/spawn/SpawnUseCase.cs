using System;
using Godot;

public interface SpawnUseCase
{
	public void Spawn<T>(T node, Node parent) where T : Node3D;
}
