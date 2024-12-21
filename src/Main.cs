using Godot;
using Chickensoft.AutoInject;
using Chickensoft.Introspection;

namespace Aestheroids;

[Meta(typeof(IProvider))]
public partial class Main : Node, IProvide<RandomNumberGenerator>
{
	public override void _Notification(int what) => this.Notify(what);

	[Export] PackedScene m_GamePackedScene;

	RandomNumberGenerator m_RandomNumberGenerator;
	RandomNumberGenerator IProvide<RandomNumberGenerator>.Value() => m_RandomNumberGenerator;


	public override void _Ready()
	{

		m_RandomNumberGenerator = new RandomNumberGenerator();
#if DEBUG
		m_RandomNumberGenerator.Seed = 0;
#endif


		Node n = m_GamePackedScene.Instantiate();
		AddChild(n);

		this.Provide();
	}


	public void OnProvided()
	{
		GD.Print($"{nameof(Main)} provided values provided.");
	}
}