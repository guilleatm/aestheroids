using Godot;
using System;

namespace Aestheroids;
public class ParticlesRepository : IParticlesRepository
{
	public PackedScene GetParticles(IParticlesRepository.ParticlesType particles)
	{
		switch (particles)
		{
			case IParticlesRepository.ParticlesType.Explosion:
			default:
				return ResourceLoader.Load<PackedScene>("res://particles/explosion_particles.tscn");
		}
	}


}
