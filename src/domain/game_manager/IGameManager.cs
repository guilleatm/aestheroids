namespace Aestheroids;

public interface IGameManager
{
    public Observable<int> Score { get; set; }
}

// public abstract partial class NGameManager : Godot.Node, IGameManager
// {
//     public abstract Observable<int> Score { get; set; }
// }