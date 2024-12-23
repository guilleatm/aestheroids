using Aestheroids;
using Chickensoft.AutoInject;
using Chickensoft.Introspection;
using Godot;
using System;

namespace Aestheroids;
[Meta(typeof(IDependent))]
public partial class ScreenDragToRotationView : Node3D
{
    public override void _Notification(int what) => this.Notify(what);
    [Export] float m_Scale;

    public Vector2 Delta => m_CurrentPosition - m_OGPosition;
    Vector2 m_OGPosition;
    Vector2 m_CurrentPosition;

    [Dependency]
    public ScreenDragToRotationUseCase m_ScreenDragToRotationUseCase => this.DependOn<ScreenDragToRotationUseCase>(() => new ScreenDragToRotationUseCaseImpl());

    public void OnResolved()
    {
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        switch (@event)
        {
            case InputEventScreenTouch screenTouch:
                if (screenTouch.Pressed)
                {
                    m_OGPosition = screenTouch.Position;
                    m_CurrentPosition = screenTouch.Position;
                }
                else
                {
                    m_CurrentPosition = screenTouch.Position;
                }
                break;

            case InputEventScreenDrag screenDrag:
                m_CurrentPosition = screenDrag.Position;

                Quaternion rotation = m_ScreenDragToRotationUseCase.GetRotation(screenDrag.Relative);
                Quaternion *= rotation;


                // RotateY(screenDrag.Relative.X * m_Scale);
                // RotateX(screenDrag.Relative.Y * m_Scale);
                // Rotate((Vector3.Up + Vector3.Right).Normalized(), screenDrag.Relative.Y * SCALE);

                break;
        }
    }
}
