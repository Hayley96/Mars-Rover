using NUnit.Framework;
using System;

namespace MarsRoverTests
{
    public class RoverTests
    {
        private Rover? rover;
        [SetUp]
        public void Setup()
        {
        }

        public void SetUpVehicle(int x, int y, string direction, string type)
        {
            rover = new(type);
        }

        [Test]
        public void TurnLeft_Returns_N_When_E_Parameter_Passed()
        {
            SetUpVehicle(1, 1, "E", "Rover");
            rover?.TurnLeft("E");
            Assert.That(rover?.Direction.ToString(), Is.EqualTo("N"));
        }

        [Test]
        public void TurnLeft_Returns_W_When_Direction_Is_N()
        {
            SetUpVehicle(1,1,"N", "Rover");
            rover?.TurnLeft("N");
            Assert.That(rover?.Direction.ToString(), Is.EqualTo("W"));
        }

        [Test]
        public void TurnRight_Returns_W_When_S_Parameter_Passed()
        {
            SetUpVehicle(1, 1, "S", "Rover");
            rover?.TurnRight("S");
            Assert.That(rover?.Direction.ToString(), Is.EqualTo("W"));
        }

        [Test]
        public void TurnRight_Returns_S_When_Direction_Is_E()
        {
            SetUpVehicle(1, 1, "E", "Rover");
            rover?.TurnRight("E");
            Assert.That(rover?.Direction.ToString(), Is.EqualTo("S"));
        }

        [Test]
        public void MoveForward_Returns_1_On_AxisY_When_Direction_Is_N_And_Starting_Y_Axis_Is_0()
        {
            SetUpVehicle(0, 0, "N", "Rover");
            rover?.MoveForward("N");
            Assert.That(rover?.AxisY, Is.EqualTo(1));
        }

        [Test]
        public void MoveForward_Returns_Minus_1_On_AxisY_When_Direction_Is_S_And_Starting_Y_Axis_Is_0()
        {
            SetUpVehicle(0, 0, "S", "Rover");
            rover?.MoveForward("S");
            Assert.That(rover?.AxisY, Is.EqualTo(-1));
        }

        [Test]
        public void TurnLeft_Throws_Exception_When_L_Parameter_Passed()
        {
            SetUpVehicle(1, 1, "E", "Rover");
            var exNull = Assert.Throws<ArgumentException>(() => rover?.TurnLeft("L"));
        }

        [Test]
        public void TurnRight_Throws_Exception_When_Q_Parameter_Passed()
        {
            SetUpVehicle(1, 1, "E", "Rover");
            var exNull = Assert.Throws<ArgumentException>(() => rover?.TurnRight("Q"));
        }

        [Test]
        public void MoveForward_Throws_Exception_When_T_Parameter_Passed()
        {
            SetUpVehicle(1, 1, "E", "Rover");
            var exNull = Assert.Throws<ArgumentException>(() => rover?.MoveForward("T"));
        }
    }
}