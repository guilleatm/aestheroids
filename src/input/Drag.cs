namespace aestheroids;

using Godot;

public partial class Drag : Node3D
{
    public Vector2 Delta => m_CurrentPosition - m_OGPosition;
    Vector2 m_OGPosition;
    Vector2 m_CurrentPosition;

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

                const float SCALE = .002f;

                RotateY(screenDrag.Relative.X * SCALE);
                RotateX(screenDrag.Relative.Y * SCALE);

                break;
        }
    }

    public override void _Process(double delta)
    {
        const float SCALE = .001f;



        // Rotation = new Vector3(Delta.Y, 0, 0);

        // RotateX(m_Velocity.Y * SCALE);
        // RotateY(-m_Velocity.X * SCALE);
    }




    // Vector2 m_Velocity;
    // bool m_Down;
    // public override void _UnhandledInput(InputEvent @event)
    // {
    //     if (@event is InputEventScreenTouch screenTouch)
    //     {
    //         m_Down = screenTouch.Pressed;
    //     }

    //     if (@event is InputEventScreenDrag screenDrag)
    //     {
    //         Vector2 dragDirection = screenDrag.ScreenRelative.Normalized();
    //         m_Velocity = screenDrag.ScreenVelocity * dragDirection;
    //     }
    // }

    // public override void _Process(double delta)
    // {
    //     const float SCALE = .00001f;
    //     if (m_Down)
    //     {
    //         RotateX(m_Velocity.Y * SCALE);
    //         RotateY(-m_Velocity.X * SCALE);
    //     }
    // }
}
