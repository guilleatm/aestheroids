using Godot;

namespace Aestheroids;

public interface ISoundRepository
{
	public enum SoundType : byte
	{
		Explosion
	}

	public AudioStream GetSound(SoundType sound);
}