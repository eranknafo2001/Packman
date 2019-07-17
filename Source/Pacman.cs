using Godot;
using System;

public class Pacman : KinematicBody2D
{
    public float speed = 200;
    private Vector2 direction = Vector2.Right;

    public override void _Ready()
    {
        
    }


    public override void _Process(float delta)
    {
        GetMoveDirection();
        Vector2 velocity = direction.Normalized() * speed * delta;
        float angle = (float)(GetAngleBetweenVectors(direction));

        Rotation = angle;

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


    private static double GetAngleBetweenVectors(Vector2 direction)
    {
        direction = direction.Normalized();

        if (direction == Vector2.Up)
            return -Math.PI / 2;
        else if (direction == Vector2.Down)
            return Math.PI / 2;
        else if (direction == Vector2.Right)
            return 0;
        else if (direction == Vector2.Left)
            return Math.PI;

        else
            return (float)(Math.Atan2((double)(direction.y - Vector2.Right.y), (double)(direction.x - Vector2.Right.x)));
    }
}
