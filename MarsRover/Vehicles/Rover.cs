public class Rover : Vehicles
{
    public Rover(string model) : base(model, 1) 
    {
        GridIcon = new ColorGrid(ConsoleColor.Red, "   ");
    }

    public override void TurnLeft(string direction)
    {
        _ = direction switch
        {
            "N" => Direction = Validation.Directions.W,
            "E" => Direction = Validation.Directions.N,
            "W" => Direction = Validation.Directions.S,
            "S" => Direction = Validation.Directions.E,
            _ => throw new ArgumentException("Direction parameter out of range")
        };
    }
    public override void TurnRight(string direction)
    {
        _ = direction switch
        {
            "N" => Direction = Validation.Directions.E,
            "E" => Direction = Validation.Directions.S,
            "W" => Direction = Validation.Directions.N,
            "S" => Direction = Validation.Directions.W,
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