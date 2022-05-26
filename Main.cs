using Godot;
using System;

public class Main : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    [Export]
    public PackedScene BulletScene;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void OnBulletFired(Vector2 position)
    {
        var bullet = (Bullet)BulletScene.Instance();
        bullet.Position = position;
        AddChild(bullet);
    }



//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
