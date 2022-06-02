using NUnit.Framework;
using System;

namespace MarsRoverTests
{
    public class PlateauTests
    {
        private Rectangle? rectangle;
        private SetUpGrid setupGrid;
        [SetUp]
        public void Setup()
        {
        }

        public void SetUpPlateau(int x, int y)
        {
            rectangle = new(x, y);
            setupGrid = new();
            setupGrid?.SetUp(x, y);
        }

        [Test]
        public void SetUpGrid_Returns_Array_Of_Color_Objects()
        {
            SetUpPlateau(1, 1);
            Assert.That(setupGrid?.Grid?.Length > 0);
        }

        [Test]
        public void SetUpGrid_Returns_Array_Of_X_Length_1_And_Y_Length_1_When_1_1_Passed_As_Parameters()
        {
            SetUpPlateau(1, 1);
            Assert.That(setupGrid?.Grid?.Length == 1);
        }

        [Test]
        public void SetUpGrid_Returns_Array_Of_Size_6_When_2_3_Passed_As_Parameters()
        {
            SetUpPlateau(2, 3);
            Assert.That(setupGrid?.Grid?.Length == 6);
        }

        [Test]
        public void SetUpGrid_Returns_Array_Of_Size_24_When_4_6_Passed_As_Parameters()
        {
            SetUpPlateau(4, 6);
            Assert.That(setupGrid?.Grid?.Length == 24);
        }
    }
}