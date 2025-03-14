using Aestheroids;
using Godot;
using System;

public partial class Planet : Area3D, IPlanet
{
    public event Action<Node3D> OnAsteroidCollided;

    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
    }

    void OnBodyEntered(Node3D body)
    {
        OnAsteroidCollided.Invoke(body);
    }
}
