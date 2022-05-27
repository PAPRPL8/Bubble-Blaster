using Godot;
using System;

public class Bullet : RigidBody2D
{
    [Export]
    public int Speed = 500;

    public void OnVisibilityNotifier2DScreenExited()
    {
        QueueFree();
    }
}
