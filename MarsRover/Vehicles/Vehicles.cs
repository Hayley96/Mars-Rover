﻿public abstract class Vehicles : IMoveable
{
    public int AxisX { get; set; }
    public int AxisY { get; set; }
    public Directions Direction { get; set; }
    public string Model { get; private set; }
    public ColorGrid? GridIcon { get; set; }

    public enum Directions { N, E, S, W, };

    public Vehicles(int asisX, int axisY, string direction, string model)
    {
        AxisX = asisX;
        AxisY = axisY;
        IsValidDirection(direction);
        Model = model;
    }

    private void IsValidDirection(string direction)
    {
        _ = direction switch
        {
            "N" => Direction = Directions.N,
            "E" => Direction = Directions.E,
            "S" => Direction = Directions.S,
            "W" => Direction = Directions.W,
            _ => throw new ArgumentException("Grade parameter out of range")
        };
    }

    public abstract void MoveForward(string direction);

    public abstract void TurnLeft(string direction);

    public abstract void TurnRight(string direction);
}