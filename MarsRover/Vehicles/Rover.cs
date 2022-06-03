public class Rover : Vehicles
{
    public Rover(int axisX, int axisY, string direction, string model) : base(axisX, axisY, direction, model) 
    {
        GridIcon = new ColorGrid(ConsoleColor.Red, " R ");
    }

    public override void TurnLeft(string direction)
    {
        _ = direction switch
        {
            "N" => Direction = Directions.W,
            "E" => Direction = Directions.N,
            "W" => Direction = Directions.S,
            "S" => Direction = Directions.E,
            _ => throw new ArgumentException("Direction parameter out of range")
        };
    }
    public override void TurnRight(string direction)
    {
        _ = direction switch
        {
            "N" => Direction = Directions.E,
            "E" => Direction = Directions.S,
            "W" => Direction = Directions.N,
            "S" => Direction = Directions.W,
            _ => throw new ArgumentException("Direction parameter out of range")
        };
    }

    public override void MoveForward(string direction)
    {
        _ = direction switch
        {
            "N" => AxisY += 1,
            "E" => AxisX += 1,
            "W" => AxisX -= 1,
            "S" => AxisY -= 1,
            _ => throw new ArgumentException("Direction parameter out of range")
        };
    }
}