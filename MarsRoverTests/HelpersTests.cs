using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FluentAssertions;

namespace MarsRoverTests
{
    public class HelpersTests
    {
        private List<string> ListTest;
        private Regex regex;
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
        public void Validation_Should_Return_True_When_Correct_Input_Format_Passed_Example_1_2()
        {
            regex = new Regex(@"^[0-9]*\s[0-9]*$");
            Validation.CheckArgs("1 2", regex).Should().Be(true);
        }

        [Test]
        public void Validation_Should_Return_True_When_Correct_Input_Format_Passed_Example_5_6()
        {
            regex = new Regex(@"^[0-9]*\s[0-9]*$");
            Validation.CheckArgs("5 6", regex).Should().Be(true);
        }

        [Test]
        public void Validation_Should_Throw_Exception_When_InCorrect_Input_Format_Passed_Example_099()
        {
            regex = new Regex(@"^[0-9]*\s[0-9]*$");
            var exNull = Assert.Throws<ArgumentException>(() => Validation.CheckArgs("099", regex));
        }

        [Test]
        public void Validation_Should_Throw_Exception_When_InCorrect_Input_Format_Passed_Example_Twenty()
        {
            regex = new Regex(@"^[0-9]*\s[0-9]*$");
            var exNull = Assert.Throws<ArgumentException>(() => Validation.CheckArgs("Twenty", regex));
        }
    }
}