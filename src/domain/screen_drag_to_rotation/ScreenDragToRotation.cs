using Aestheroids;
using Chickensoft.AutoInject;
using Chickensoft.Introspection;
using Godot;
using System;

namespace Aestheroids;
[Meta(typeof(IDependent))]
public partial class ScreenDragToRotation : Node3D
{
    public override void _Notification(int what) => this.Notify(what);
    [Export] float m_Scale;
    [Export] Camera3D m_Camera;

    public Vector2 Delta => m_CurrentPosition - m_OGPosition;
    Vector2 m_OGPosition;
    Vector2 m_CurrentPosition;

    [Dependency]
    public ScreenDragToRotationUseCase m_ScreenDragToRotationUseCase => this.DependOn<ScreenDragToRotationUseCase>(() => new ScreenDragToRotationUseCaseImpl());

    public void OnResolved()
    {
    }

    public override void _Input(InputEvent @event)
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

                Quaternion cameraRotation = m_Camera.GlobalBasis.GetRotationQuaternion();

                Quaternion rotation = m_ScreenDragToRotationUseCase.GetRotation(screenDrag.Relative);
                Quaternion = cameraRotation * rotation * cameraRotation.Inverse() * Quaternion;
                break;
        }
    }

    // public override void _UnhandledInput(InputEvent @event) { }
}
