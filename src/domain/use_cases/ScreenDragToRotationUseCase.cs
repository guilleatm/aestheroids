using Godot;
using System;

public interface ScreenDragToRotationUseCase
{
	public Quaternion GetRotation(Vector2 screenDrag);
}
