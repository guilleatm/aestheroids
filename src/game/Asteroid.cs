using Godot;
using System;

namespace Aestheroids;
public partial class Asteroid : RigidBody3D
{
	[Export] public RigidBody3D RigidBody3D;
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}
}
