using Aestheroids;
using Godot;
using System;

public class DestroyAsteroidUseCaseImpl : DestroyAsteroidUseCase<Asteroid>
{
	PackedScene m_ExplosionParticles;
	AudioStream m_ExplosionSound;

	public DestroyAsteroidUseCaseImpl(IParticlesRepository particlesRepository, ISoundRepository soundRepository)
	{
		m_ExplosionParticles = particlesRepository.GetParticles(IParticlesRepository.ParticlesType.Explosion);
		m_ExplosionSound = soundRepository.GetSound(ISoundRepository.SoundType.Explosion);
	}

	public void DestroyAsteroid(Asteroid asteroid)
	{

		// PARTICLES
		CpuParticles3D particles = m_ExplosionParticles.Instantiate<CpuParticles3D>();
		asteroid.GetTree().Root.AddChild(particles);

		particles.GlobalPosition = asteroid.GlobalPosition;
		particles.Emitting = true;


		// SOUND
		AudioStreamPlayer3D audioPlayer = new AudioStreamPlayer3D();
		asteroid.GetTree().Root.AddChild(audioPlayer);

		audioPlayer.Stream = m_ExplosionSound;
		audioPlayer.Play();


		// #C GC takes care of this?
		SceneTreeTimer timer = asteroid.GetTree().CreateTimer(4);
		timer.Timeout += () =>
		{
			particles.GetParent().RemoveChild(particles);
			particles.QueueFree();

			audioPlayer.GetParent().RemoveChild(audioPlayer);
			audioPlayer.QueueFree();
		};
	}
}
