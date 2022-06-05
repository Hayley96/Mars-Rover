using NUnit.Framework;
using System;

namespace MarsRoverTests
{
    public class VehicleManagerTests
    {
        private VehicleManager? vehicleManager;
        [SetUp]
        public void Setup()
        {
        }

        public void SetUpPlateau(int x, int y)
        {
            vehicleManager = new();
        }

        [Test]
        public void VehicleManager_Should_Return_A_Instance_Of_Type_Selected_By_Input()
        {
            SetUpPlateau(1, 1);
            vehicleManager?.PrepareVehicle("Rover");
            Assert.That(vehicleManager?.Vehicle?.Model, Is.EqualTo("Rover"));
            Assert.That(vehicleManager?.Vehicle?.AxisX, Is.EqualTo(0));
            Assert.That(vehicleManager?.Vehicle?.AxisY, Is.EqualTo(0));
            Assert.That(vehicleManager?.Vehicle?.Direction.ToString(), Is.EqualTo("E"));
        }
    }
}