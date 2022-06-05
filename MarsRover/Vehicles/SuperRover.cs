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
            "N" => AxisY += 2,
            "E" => AxisX += 2,
            "W" => AxisX -= 2,
            "S" => AxisY -= 2,
            _ => throw new ArgumentException("Direction parameter out of range")
        };
    }
}