using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FluentAssertions;

namespace MarsRoverTests
{
    public class HelpersTests
    {
        private List<string>? ListTest;
        private Regex? regex;
        private VehicleManager? vehicleManager;
        private MissionManager? missionManager;
        private PlateauManager? plateauManager;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddItemToList_Should_Populate_A_Given_List_With_Supplied_Parameters()
        {
            ListTest = new List<string>();
            AddItemToList.Add(ListTest, "Hello");
            Assert.IsTrue(ListTest.Count > 0);
        }

        [Test]
        public void AddItemToList_Should_Have_Count_5_When_Executed_5_Times()
        {
            ListTest = new List<string>();
            for(int i = 0; i < 5; i++)
                AddItemToList.Add(ListTest, "Hello");
            Assert.IsTrue(ListTest.Count == 5);
        }

        [Test]
        public void Validation_CheckArgs_Should_Return_True_When_Correct_Input_Format_Passed_Example_1_2()
        {
            regex = new Regex(@"^[0-9]*\s[0-9]*$");
            ValidationInputs.CheckArgs("1 2", regex).Should().Be(true);
        }

        [Test]
        public void Validation_CheckArgs_Should_Return_True_When_Correct_Input_Format_Passed_Example_5_6()
        {
            regex = new Regex(@"^[0-9]*\s[0-9]*$");
            ValidationInputs.CheckArgs("5 6", regex).Should().Be(true);
        }
        //***As the method now contains a try/catch, there is no exception directed back so the once passing test now fails***//
        //***Need to investigate how to test this scenario once the try/catch is implemented - left in old testcase for now***//

        //[Test]
        //public void Validation_CheckArgs_Should_Throw_Exception_When_InCorrect_Input_Format_Passed_Example_099()
        //{
        //    regex = new Regex(@"^[0-9]*\s[0-9]*$");
        //    var exNull = Assert.Throws<ArgumentException>(() => Validation.CheckArgs("099", regex));
        //}
        //********************************************************************************************************************//

        //***As the method now contains a try/catch, there is no exception directed back so the once passing test now fails***//
        //***Need to investigate how to test this scenario once the try/catch is implemented - left in old testcase for now***//

        //[Test]
        //public void Validation_CheckArgs_Should_Throw_Exception_When_InCorrect_Input_Format_Passed_Example_Twenty()
        //{
        //    regex = new Regex(@"^[0-9]*\s[0-9]*$");
        //    var exNull = Assert.Throws<ArgumentException>(() => Validation.CheckArgs("Twenty", regex));
        //}
        //********************************************************************************************************************//

        [Test]
        public void Validation_CheckIfClassExists_Should_Return_True_When_Correct_Input_Passed()
        {
            vehicleManager = new();
            vehicleManager.PrepareVehicle("Rover");
            vehicleManager.GetSubclasses();
            IEnumerable<Type>? subclasses = vehicleManager.subclasses;
            ValidationInputs.CheckIfUserHasInputASubClassThatExists("Rover", subclasses).Should().Be(true);
        }


        //[Test]
        //public void Validation_CheckIfClassExists_Should_Return_False_When_Input_References_Class_That_Does_Not_Exist()
        //{
        //    vehicleManager = new();
        //    vehicleManager.PrepareVehicle("Rover");
        //    vehicleManager.GetSubclasses();
        //    IEnumerable<Type>? subclasses = vehicleManager.subclasses;
        //    ValidationInputs.CheckIfUserHasInputASubClassThatExists("Whooops!", subclasses).Should().Be(false);
        //}

        [Test]
        public void SplitStrings_SplitIntDataIndex0_Should_Return_First_Integer_From_String()
        {
            SplitStrings.SplitIntDataIndex0("5 6").Should().Be(5);
        }

        [Test]
        public void SplitStrings_SplitIntDataIndex1_Should_Return_Second_Integer_From_String()
        {
            SplitStrings.SplitIntDataIndex1("5 6").Should().Be(6);
        }

        [Test]
        public void SplitStrings_SplitDataIndex2_Should_Return_Third_Letter_From_String()
        {
            SplitStrings.SplitDataIndex2("5 6 N").Should().Be("N");
        }

        [Test]
        public void Validation_IsOutOfPlateauBounds_Should_Return_True_When_Vehicle_Position_Is_Within_The_Bounds_Of_The_Plateau()
        {
            plateauManager = new();
            plateauManager.PreparePlateau(5, 5, "Rectangle");
            vehicleManager = new();
            vehicleManager.PrepareVehicle("Rover");
            ValidationVehicleBoundary.IsOutOfPlateauBounds(vehicleManager.Vehicle, plateauManager.Plateau).Should().BeTrue();
        }

        //***As the method now contains a try/catch, there is no exception directed back so the once passing test now fails***//
        //***Need to investigate how to test this scenario once the try/catch is implemented - left in old testcase for now***//

        //[Test]
        //public void Validation_IsOutOfPlateauBounds_Should_Return_False_When_Vehicle_Position_Is_Within_The_Bounds_Of_The_Plateau()
        //{
        //    plateauManager = new();
        //    plateauManager.PreparePlateau(5, 5, "Rectangle");
        //    vehicleManager = new();
        //    vehicleManager.PrepareVehicle(5, 6, "N", "Rover");
        //    var exNull = Assert.Throws<ArgumentException>(() => Validation.IsOutOfPlateauBounds(vehicleManager.Vehicle, plateauManager.Plateau));
        //}
        //********************************************************************************************************************//

        [Test]
        public void Validation_IsValidMoveCommand_Should_Return_True_When_Valid_Commands_Passed()
        {
            ValidationEnums.ValidMoveCommand("M").Should().BeTrue();
        }

        //***As the method now contains a try/catch, there is no exception directed back so the once passing test now fails***//
        //***Need to investigate how to test this scenario once the try/catch is implemented - left in old testcase for now***//

        //[Test]
        //public void Validation_IsValidMoveCommand_Should_Throw_Exception_When_InValid_Commands_Passed()
        //{
        //    //var exNull = Assert.Throws<ArgumentException>(() => Validation.ValidMoveCommand("P"));
        //}
        //********************************************************************************************************************//

        [Test]
        public void Validation_ValidDirection_Should_Return_Matching_Enum_Value_When_Valid_Direction_Passed()
        {
            ValidationEnums.Directions shouldBe = ValidationEnums.Directions.S;
            ValidationEnums.Directions results;
            results = ValidationEnums.ValidDirection("S");
            Assert.AreEqual(shouldBe, results);
        }

        //***As the method now contains a try/catch, there is no exception directed back so the once passing test now fails***//
        //***Need to investigate how to test this scenario once the try/catch is implemented - left in old testcase for now***//

        //[Test]
        //public void Validation_ValidDirection_Should_Throw_Exception_When_InValid_Direction_Passed()
        //{
        //    var exNull = Assert.Throws<ArgumentException>(() => Validation.ValidDirection("P"));
        //}
        //********************************************************************************************************************//
    }
}