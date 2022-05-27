using Godot;
using System;

public class Main : Node
{
    public void OnBulletFired(PackedScene bullet, Vector2 position, float rotation)
    {
        var bulletInstance = (Bullet)bullet.Instance();
        AddChild(bulletInstance);

        bulletInstance.Position = position;
        bulletInstance.Rotation = rotation;
        
        var velocity = new Vector2(bulletInstance.Speed, 0);
        bulletInstance.LinearVelocity = velocity.Rotated(rotation);
    }
}
