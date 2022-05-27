using Godot;
using System;

public class Ship : Node2D
{
    [Export]
    public int Speed = 400;

    public Vector2 ScreenSize;
    public Vector2 velocity = new Vector2();

    private PackedScene _bullet = GD.Load<PackedScene>("res://Bullet.tscn");

    [Signal]
    public delegate void FireBullet(PackedScene _bullet, Vector2 position, float rotation);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        ScreenSize = GetViewportRect().Size;
    }

    public override void _Process(float delta)
    {
        var velocity = Vector2.Zero; // The player's movement vector.

        if (Input.IsActionPressed("move_right"))
        {
            velocity.x += 1;
        }

        if (Input.IsActionPressed("move_left"))
        {
            velocity.x -= 1;
        }

        if (Input.IsActionPressed("move_down"))
        {
            velocity.y += 1;
        }

        if (Input.IsActionPressed("move_up"))
        {
            velocity.y -= 1;
        }

        var shipPolygon2D = GetNode<Polygon2D>("Polygon2D");
        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() * Speed;
        }

        Position += velocity * delta;
        Position = new Vector2(
            x: Mathf.Clamp(Position.x, 0, ScreenSize.x),
            y: Mathf.Clamp(Position.y, 0, ScreenSize.y)
        );

        LookAt(GetGlobalMousePosition());
    }

    public override void _Input(InputEvent @event)
    {
        // Mouse in viewport coordinates.
        if (@event is InputEventMouseButton eventMouseButton)
        {
            //GD.Print("Mouse Click/Unclick at: ", eventMouseButton.Position);
            if (eventMouseButton.ButtonIndex == (int)ButtonList.Left && eventMouseButton.Pressed)
            {
                EmitSignal(nameof(FireBullet), _bullet, Position, Rotation);
            }
        }
    }
}
