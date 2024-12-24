using Godot;
using System;

public partial class AutoRotator : Node3D
{

	[Export]
	Vector3 Axis
	{
		get => m_Axis;
		set
		{
			m_Axis = value;
			m_AxisNormalized = m_Axis.Normalized();
		}
	}

	[Export]
	public float Velocity { get; set; }

	Vector3 m_Axis;
	Vector3 m_AxisNormalized;


	public override void _Process(double delta)
	{
		Rotate(m_AxisNormalized, (float)(Velocity * delta));
	}
}
