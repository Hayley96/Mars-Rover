using NUnit.Framework;
using System;

namespace MarsRoverTests
{
    public class PlateauManagerTests
    {
        private PlateauManager? plateauManager;
        [SetUp]
        public void Setup()
        {
            plateauManager = new();
        }

        [Test]
        public void PlateauManager_Should_Return_A_Instance_Of_Type_PlateauShapess_As_Selected_By_Input()
        {
            plateauManager?.PreparePlateau(5, 6, "Rectangle");
            Assert.That(plateauManager?.Plateau?.PlateauSizeX, Is.EqualTo(5));
            Assert.That(plateauManager?.Plateau?.PlateauSizeY, Is.EqualTo(6));
        }
    }
}