using Godot;
using System;

public class Bullet : Polygon2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    [Export]
    public int Speed = 400;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
         ScreenSize = GetViewportRect().Size;
    }

        public Vector2 ScreenSize;

    public override void _Process(float delta)
    {
        var velocity = Vector2.Zero; // The player's movement vector.

            velocity.x += 1;

            //velocity.x -= 1;

        //if (Input.IsActionPressed("move_down"))
        //{
        //    velocity.y += 1;
       // }

        //if (Input.IsActionPressed("move_up"))
        //{
        //    velocity.y -= 1;
        //}

            velocity = velocity.Normalized() * Speed;

        Position += velocity * delta;
        Position = new Vector2(
            x: Mathf.Clamp(Position.x, 0, ScreenSize.x),
            y: Mathf.Clamp(Position.y, 0, ScreenSize.y)
        );

    }

}
