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
            vehicleManager = new();
        }

        [Test]
        public void VehicleManager_Should_Return_A_Instance_Of_Type_Selected_By_Input()
        {
            vehicleManager?.PrepareVehicle("Rover");
            Assert.That(vehicleManager?.Vehicle?.Model, Is.EqualTo("Rover"));
        }
    }
}