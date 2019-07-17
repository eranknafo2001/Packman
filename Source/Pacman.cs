using Godot;
using System;

public class Pacman : KinematicBody2D
{
    public float speed = 2;
    private Vector2 direction = Vector2.Right;

    public override void _Ready()
    {
        
    }


    public override void _Process(float delta)
    {
        GetMoveDirection();
        Vector2 velocity = direction.Normalized() * speed;

        MoveAndCollide(velocity, true);
    }

    private void GetMoveDirection()
    {
        if (Input.IsActionPressed("up"))
            direction = Vector2.Up;
        else if (Input.IsActionPressed("down"))
            direction = Vector2.Down;
        else if (Input.IsActionPressed("right"))
            direction = Vector2.Right;
        else if (Input.IsActionPressed("left"))
            direction = Vector2.Left;
    }
}
