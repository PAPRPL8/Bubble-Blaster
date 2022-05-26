using Godot;
using System;

public class Ship : Node2D
{
    [Export]
    public int Speed = 400;

    public Vector2 ScreenSize;
    public Vector2 velocity = new Vector2();

    [Signal]
    public delegate void FireBullet(Vector2 position);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        ScreenSize = GetViewportRect().Size;
    }

    public override void _PhysicsProcess(float delta)
    {
        //GetInput();
        //velocity = MoveAndSlide(velocity);
    }

     public void GetInput()
    {
        LookAt(GetGlobalMousePosition());
        velocity = new Vector2();

        if (Input.IsActionPressed("down"))
            velocity = new Vector2(-Speed, 0).Rotated(Rotation);

        if (Input.IsActionPressed("up"))
            velocity = new Vector2(Speed, 0).Rotated(Rotation);

        velocity = velocity.Normalized() * Speed;
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
            if (eventMouseButton.Pressed)
            {
                EmitSignal(nameof(FireBullet), this.Position);
            }
        }
        //else if (@event is InputEventMouseMotion eventMouseMotion)
            //GD.Print("Mouse Motion at: ", eventMouseMotion.Position);

        // Print the size of the viewport.
        //GD.Print("Viewport Resolution is: ", GetViewportRect().Size);
    }


    //private void FireBullet()
    //{
    //    // Create a new instance of the Mob scene.
    //    var bullet = (Bullet)BulletScene.Instance();
//
    //    // Set the mob's direction perpendicular to the path direction.
    //    //float direction = mousePosition.Rotation + Mathf.Pi / 2;
//
    //    // Set the mob's position to a random location.
    //    bullet.Position = Position;
//
    //    float direction = bullet.Rotation;
//
    //    // Add some randomness to the direction.
    //    
    //   // direction += (float)GD.RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
    //    
    //    bullet.Rotation = direction;
//
    //    // Choose the velocity.
    //    //var velocity = new Vector2((float)GD.RandRange(150.0, 250.0), 0);
    //    //bullet.LinearVelocity = velocity.Rotated(direction);
//
    //    // Spawn the mob by adding it to the Main scene.
    //    AddChild(bullet);
//
    //}

}
