public class SuperRover : Vehicles
{
    public SuperRover(string model) : base(model, 2) 
    {
        GridIcon = new ColorGrid(ConsoleColor.Green, "   ");
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
            "N" => AxisY += 2,
            "E" => AxisX += 2,
            "W" => AxisX -= 2,
            "S" => AxisY -= 2,
            _ => throw new ArgumentException("Direction parameter out of range")
        };
    }
}