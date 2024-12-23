namespace Aestheroids;

using Godot;

public partial class ScreenDragToRotationUseCaseImpl : ScreenDragToRotationUseCase
{
    public Quaternion GetRotation(Vector2 screenDrag)
    {
        return Quaternion.FromEuler(new Vector3(screenDrag.X, screenDrag.Y, 0));
    }
}
