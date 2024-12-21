using System;
using Godot;

public partial class SpawnUseCaseImpl : SpawnUseCase
{
	RandomNumberGenerator m_RandomNumbergenerator;
	float m_Radius;
	public SpawnUseCaseImpl(RandomNumberGenerator randomNumberGenerator, float radius)
	{
		m_RandomNumbergenerator = randomNumberGenerator;
		m_Radius = radius;
	}

	public void Spawn<T>(T node, Node parent) where T : Node3D
	{
		Vector3 position = m_RandomNumbergenerator.GetV3OnSphere(m_Radius);

		node.GlobalPosition = position;
		// node.GlobalRotation = rotation;
		parent.AddChild(node);
	}
}
