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
            "N" => Direction = ValidationEnums.Directions.W,
            "E" => Direction = ValidationEnums.Directions.N,
            "W" => Direction = ValidationEnums.Directions.S,
            "S" => Direction = ValidationEnums.Directions.E,
            _ => throw new ArgumentException("Direction parameter out of range")
        };
    }
    public override void TurnRight(string direction)
    {
        _ = direction switch
        {
            "N" => Direction = ValidationEnums.Directions.E,
            "E" => Direction = ValidationEnums.Directions.S,
            "W" => Direction = ValidationEnums.Directions.N,
            "S" => Direction = ValidationEnums.Directions.W,
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