using Aestheroids;
using Godot;
using System;

public class DestroyAsteroidUseCaseImpl : DestroyAsteroidUseCase<Asteroid>
{
	PackedScene m_ExplosionParticles;

	public DestroyAsteroidUseCaseImpl(IParticlesRepository particlesRepository)
	{
		m_ExplosionParticles = particlesRepository.GetParticles(IParticlesRepository.ParticlesType.Explosion);
	}

	public void DestroyAsteroid(Asteroid asteroid)
	{
		CpuParticles3D particles = m_ExplosionParticles.Instantiate<CpuParticles3D>();
		asteroid.GetTree().Root.AddChild(particles);

		particles.GlobalPosition = asteroid.GlobalPosition;
		particles.Emitting = true;
	}
}
