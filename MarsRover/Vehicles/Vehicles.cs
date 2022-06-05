public abstract class Vehicles : IMoveable
{
    public int AxisX { get; set; } = 0;
    public int AxisY { get; set; } = 0;
    public Validation.Directions Direction { get; set; }
    public string Model { get; private set; }
    public ColorGrid? GridIcon { get; set; }

    public int NumberOfStepsCapableOfPerforming { get; private set; }

    public Vehicles(string model, int stepsCanTake)
    {
        Model = model;
        NumberOfStepsCapableOfPerforming = stepsCanTake;
    }

    public abstract void MoveForward(string direction);

    public abstract void TurnLeft(string direction);

    public abstract void TurnRight(string direction);
}