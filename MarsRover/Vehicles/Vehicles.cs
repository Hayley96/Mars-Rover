public abstract class Vehicles : IMoveable
{
    public int AxisX { get; set; }
    public int AxisY { get; set; }
    public Validation.Directions Direction { get; set; }
    public string Model { get; private set; }
    public ColorGrid? GridIcon { get; set; }

    public int NumberOfStepsCapableOfPerforming { get; private set; }

    public Vehicles(int asisX, int axisY, string direction, string model, int stepsCanTake)
    {
        AxisX = asisX;
        AxisY = axisY;
        Direction = Validation.ValidDirection(direction);
        Model = model;
        NumberOfStepsCapableOfPerforming = stepsCanTake;
    }

    public abstract void MoveForward(string direction);

    public abstract void TurnLeft(string direction);

    public abstract void TurnRight(string direction);
}