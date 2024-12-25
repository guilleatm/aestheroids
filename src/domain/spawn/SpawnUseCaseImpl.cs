using System;
using Godot;

public partial class SpawnUseCaseImpl : SpawnUseCase
{
	RandomNumberGenerator m_RandomNumberGenerator;
	float m_Radius;
	public SpawnUseCaseImpl(RandomNumberGenerator randomNumberGenerator, float radius)
	{
		m_RandomNumberGenerator = randomNumberGenerator;
		m_Radius = radius;
	}

	public void Spawn<T>(T node, Node parent) where T : Node3D
	{
		Vector3 position = m_RandomNumberGenerator.GetV3OnSphere(m_Radius);
		parent.AddChild(node);

		node.GlobalPosition = position;
		node.LookAt(Vector3.Zero);
	}
}
