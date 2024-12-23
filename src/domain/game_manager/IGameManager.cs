namespace Aestheroids;

public interface IGameManager
{
    public Observable<int> Score { get; protected set; }
}