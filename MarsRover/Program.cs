Rover rover = new(1, 1, "N", "Rover");
rover.MoveForward("N");
Console.WriteLine($"{rover.AxisX} {rover.AxisY}");

Rectangle rectangle = new(5, 6);
SetUpGrid setGrid = new();
setGrid.SetUp(rectangle.PlateauSizeX, rectangle.PlateauSizeY);
rectangle.Draw(rectangle.PlateauSizeX, rectangle.PlateauSizeY, setGrid.Grid);