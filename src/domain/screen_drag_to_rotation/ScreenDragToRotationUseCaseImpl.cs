namespace Aestheroids;

using Godot;

public partial class ScreenDragToRotationUseCaseImpl : ScreenDragToRotationUseCase
{
    public Quaternion GetRotation(Vector2 screenDrag)
    {
        return Quaternion.FromEuler(new Vector3(Mathf.DegToRad(screenDrag.Y), Mathf.DegToRad(screenDrag.X), 0));
    }
}
