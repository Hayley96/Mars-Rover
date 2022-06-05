using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FluentAssertions;

namespace MarsRoverTests
{
    public class MoveCommandsTests
    {
        private VehicleManager? vehicleManager;
        private PlateauManager? plateauManager;
        private MoveCommands moveCommands;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MoveCommands_Should_Modify_The_X_And_Y_Coordinates_Of_The_Supplied_Vehicle()
        {
            plateauManager = new();
            plateauManager.PreparePlateau(5, 5, "Rectangle");
            vehicleManager = new();
            vehicleManager.PrepareVehicle("Rover");
            moveCommands = new();
            moveCommands.RunVehicleMoveCommands("MM", vehicleManager.Vehicle, plateauManager.Plateau);
            Assert.IsTrue(vehicleManager.Vehicle.AxisY.Equals(2));
        }
    }
}