using System;
using Godot;

public partial class SpawnUseCaseImpl : SpawnUseCase
{
	RandomNumberGenerator m_RandomNumbergenerator;
	public SpawnUseCaseImpl(RandomNumberGenerator randomNumberGenerator)
	{
		m_RandomNumbergenerator = randomNumberGenerator;
	}

	public void Spawn<T>(T node, float radius, Node parent) where T : Node3D
	{
		Vector3 position = m_RandomNumbergenerator.GetV3OnSphere(radius);

		node.GlobalPosition = position;
		// node.GlobalRotation = rotation;
		parent.AddChild(node);
	}
}
