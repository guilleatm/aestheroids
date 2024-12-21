namespace Aestheroids;

public interface GameManagerUseCase
{
    public Observable<int> Score { get; protected set; }
}