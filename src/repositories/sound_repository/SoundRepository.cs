using Godot;


namespace Aestheroids;
public class SoundRepository : ISoundRepository
{
	public AudioStream GetSound(ISoundRepository.SoundType sound)
	{
		switch (sound)
		{
			case ISoundRepository.SoundType.Explosion:
			default:
				return ResourceLoader.Load<AudioStream>("res://sounds/explosion.wav");
		}
	}
}
