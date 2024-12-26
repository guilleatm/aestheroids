using Godot;
using System;

namespace Aestheroids;

public interface IParticlesRepository
{
	public enum ParticlesType : byte
	{
		Explosion
	}

	public PackedScene GetParticles(ParticlesType particles);

}
